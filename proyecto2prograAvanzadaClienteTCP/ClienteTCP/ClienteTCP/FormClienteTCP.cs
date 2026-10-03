/*
UNED 3 Cuatrimestre 2025
Proyecto 2 Programación Avanzada  Descrición: Videojuego de batallas de criaturas místicas.
Estudiante: Andrés Céspedes Siles
Fecha:9/11/2025
Referencias:
 Tutoria #2 Acosta Johan     https://www.youtube.com/watch?v=K4nriwB63qk
 Tutoria #2 Ramirez Juan     https://www.youtube.com/watch?v=b3cB65mMVXU
 Tutoria #3 Figueroa Johan   https://www.youtube.com/watch?v=64m_afGunoQ
Deitel, H. M.  (2007). Cómo programar en C#,  2nd Edition. [[VitalSource Bookshelf version]].  Retrieved from vbk://9789702610564
*/




using System.Net.Sockets;
using System.Text;

namespace ClienteTCP
{
    public partial class FormClienteTCP : Form
    {
        private TcpClient cliente;
        private NetworkStream stream;
        private bool jugadorValidado = false;
        private string nombreJugador = "";
        private int IdJugador;
        public FormClienteTCP()
        {
            InitializeComponent();
            txtEstadoServidor.Text = "Desconectado";
            txtEstadoServidor.ReadOnly = true;
            btnRegistConsultCriaturas.Enabled = false;
            btnRegistConsultBatalla.Enabled = false;
            btnConsultas.Enabled = false;

        }

        private void btnConectar_Click(object sender, EventArgs e)  //incia conexion con servidor
        {
            try
            {
                // Conexión al servidor
                cliente = new TcpClient("127.0.0.1", 14100);    //puerto solictado para conexion
                stream = cliente.GetStream();
                txtEstadoServidor.Text = " Conectado al servidor";

                // Validación de usuario
                string usuario = txtUsuario.Text.Trim();
                string contrasena = txtContrasena.Text.Trim();

                if (usuario == "" || contrasena == "")
                {
                    MessageBox.Show("Por favor ingresa usuario y contraseña.");
                    txtEstadoServidor.Text = " No pueden haber campos vacíos";
                    return;
                }

                string solicitud = $"LOGIN|{usuario}|{contrasena}";
                byte[] datos = Encoding.UTF8.GetBytes(solicitud);
                stream.Write(datos, 0, datos.Length);

                string respuesta = "";


                Task.Run(() =>
                {
                    try
                    {
                        byte[] buffer = new byte[1024];
                        int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                        string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);

                        Invoke(new Action(() =>
                        {
                            if (respuesta.StartsWith("OK|"))
                            {
                                string[] partes = respuesta.Split('|');
                                string nombreJugador = partes[1];
                                IdJugador = Convert.ToInt32(partes[2]);
                                txtNombreJugador.Text = $"Bienvenido {nombreJugador}-{IdJugador}";
                                txtEstadoServidor.Text = $"Conectado";
                                jugadorValidado = true;

                                // Activar funcionalidades
                                btnRegistConsultCriaturas.Enabled = true;
                                btnRegistConsultBatalla.Enabled = true;
                                btnConsultas.Enabled = true;
                            }
                            else
                            {
                                txtEstadoServidor.Text = "Desconectado";
                                MessageBox.Show("Usuario no válido o no está registrado.");

                                // 🔒 Limpiar campos y bloquear funcionalidades
                                txtUsuario.Text = "";
                                txtContrasena.Text = "";
                                txtNombreJugador.Text = "";

                                btnRegistConsultCriaturas.Enabled = false;
                                btnRegistConsultBatalla.Enabled = false;
                                btnConsultas.Enabled = false;
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            txtEstadoServidor.Text = " Error de lectura";
                            MessageBox.Show("Error al leer del servidor: " + ex.Message);
                        }));
                    }
                });

            }
            catch (Exception ex)
            {
                txtEstadoServidor.Text = " Error de conexión";
                MessageBox.Show("No se pudo conectar al servidor: " + ex.Message);
            }
        }

        private void btnRegistConsultCriaturas_Click(object sender, EventArgs e)

        {
            FormRegistroCriaturas InventarioForm = new FormRegistroCriaturas(nombreJugador, cliente, stream, IdJugador);
            InventarioForm.ShowDialog();
        }



        private void txtNombreJugador_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            
            NetworkStream stream = cliente.GetStream();
            FormTopGanadores topGanadoresForm = new FormTopGanadores(stream,IdJugador);
            topGanadoresForm.ShowDialog();
        }

        private void btnRegistConsultBatalla_Click(object sender, EventArgs e)
        {
            FormBatalla batallaForm = new FormBatalla(stream, IdJugador);
            batallaForm.ShowDialog();

        }
    }
}





