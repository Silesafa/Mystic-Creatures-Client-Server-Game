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
using Newtonsoft.Json;
using Entidades;


namespace ClienteTCP
{
    public partial class FormInventarioCliente : Form
    {
        private string nombreJugador;
        private TcpClient cliente;
        private NetworkStream stream;

        public FormInventarioCliente(string nombreJugador, TcpClient cliente, NetworkStream stream)
        {

            InitializeComponent();
            this.nombreJugador = nombreJugador;
            this.cliente = cliente;
            this.stream = stream;


        }

        private void FormInventarioCliente_Load(object sender, EventArgs e)// envia solictud al server para cargar inventario
        {
            try
            {
                string solicitud = $"INVENTARIO|{nombreJugador}";
                byte[] datos = Encoding.UTF8.GetBytes(solicitud);
                stream.Write(datos, 0, datos.Length);

                byte[] buffer = new byte[4096];
                int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);

                var inventario = JsonConvert.DeserializeObject<List<CriaturaEntidad>>(respuesta); //covierte la cadena del json a una lista
                dgvInventario.DataSource = inventario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario: " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); //cierra pantalla
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string idJugador = txtIdJugador.Text.Trim();
            string idCriatura = txtIdCriatura.Text.Trim();

            var mensaje = new MensajeTCP("COMPRARCRIATURA", idJugador, idCriatura);
            byte[] datos = Encoding.UTF8.GetBytes(mensaje.ToString());
            stream.Write(datos, 0, datos.Length);

            byte[] buffer = new byte[4096];
            int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
            string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
            var respuestaTCP = MensajeTCP.Parse(respuesta);

            if (respuestaTCP.Comando == "OK")
            {
                string json = string.Join("|", respuestaTCP.Parametros);
                var inventario = JsonConvert.DeserializeObject<List<CriaturaEntidad>>(json); //covierte la cadena del json a una lista de objetos
                dgvInventario.DataSource = inventario;
                MessageBox.Show("Criatura registrada exitosamente.");
            }
            else
            {
                MessageBox.Show(string.Join(" ", respuestaTCP.Parametros));
            }

        }

        private void FormInventarioCliente_Load_1(object sender, EventArgs e)
        {

        }
    }
}