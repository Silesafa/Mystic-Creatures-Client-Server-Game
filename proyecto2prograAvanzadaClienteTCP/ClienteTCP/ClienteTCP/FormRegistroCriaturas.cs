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

using AccesoDatos;
using Entidades;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;


namespace ClienteTCP
{
    public partial class FormRegistroCriaturas : Form

    {

        private JugadorEntidad jugador;


        TcpClient cliente;
        NetworkStream stream;
        bool jugadorValidado = false;
        string nombreJugador;
        int IdJugador;
        public FormRegistroCriaturas(string nombreJugador, TcpClient cliente, NetworkStream stream, int IdJugador)
        {
            InitializeComponent();
            this.nombreJugador = nombreJugador;
            this.cliente = cliente;
            this.stream = stream;
            this.IdJugador = IdJugador;


        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (stream == null)
            {
                MessageBox.Show("Debes estar conectado y validado para consultar.");
                return;
            }
             
            Task.Run(() =>  //permite realizar tareas sin afectar hilo principal
            {
                try
                {
                    string solicitud = $"LISTA_CRIATURAS|{IdJugador}";
                    byte[] datos = Encoding.UTF8.GetBytes(solicitud);
                    stream.Write(datos, 0, datos.Length);

                    byte[] buffer = new byte[4096];
                    int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                    string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);

                    Invoke(new Action(() => //ejecuta hilo principal de la GUI desde un hilo secundario
                    {
                        if (respuesta.StartsWith("LISTA|"))
                        {


                            string json = respuesta.Substring(6);
                            var Respuesta = JsonConvert.DeserializeObject<RespuestaInventarioEntidad>(json);
                            jugador = Respuesta.Jugador;

                            Invoke(new Action(() =>//ejecuta hilo principal de la GUI desde un hilo secundario
                            {

                                ActualizarGridCriaturas(Respuesta.ListaCriaturas);
                                ActualizarGridInventarioJugador(Respuesta.ListaCriaturasPorJugador);

                            }));


                        }


                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>//ejecuta hilo principal de la GUI desde un hilo secundario
                    {

                        MessageBox.Show("Error al enviar solicitud: " + ex.Message);
                    }));
                }
            });
        }

        private void ActualizarGridCriaturas(List<CriaturaEntidad> criaturas)
        {
            dgvCriaturas.Rows.Clear();        //Se limpian filas y columnas del dgv
            dgvCriaturas.Columns.Clear();

            dgvCriaturas.Columns.Add("IdCriatura", "ID");
            dgvCriaturas.Columns.Add("Nombre", "Nombre");
            dgvCriaturas.Columns.Add("Tipo", "Tipo");
            dgvCriaturas.Columns.Add("Nivel", "Nivel");
            dgvCriaturas.Columns.Add("Poder", "Poder");
            dgvCriaturas.Columns.Add("Resistencia", "Resistencia");
            dgvCriaturas.Columns.Add("Costo", "Costo");


            foreach (var item in criaturas)
            {


                dgvCriaturas.Rows.Add(
                  item.IdCriatura,
                  item.Nombre,
                  item.Tipo,
                  "",
                  item.Poder,
                  item.Resistencia,
                  item.Costo);
            }

        }

        private void ActualizarGridInventarioJugador(List<CriaturaEntidad> criaturas)
        {
            dgvInventarioJugador.Rows.Clear();        //Se limpian filas y columnas del dgv
            dgvInventarioJugador.Columns.Clear();

            dgvInventarioJugador.Columns.Add("IdCriatura", "ID");
            dgvInventarioJugador.Columns.Add("Nombre", "Nombre");
            dgvInventarioJugador.Columns.Add("Tipo", "Tipo");
            dgvInventarioJugador.Columns.Add("Nivel", "Nivel");
            dgvInventarioJugador.Columns.Add("Poder", "Poder");
            dgvInventarioJugador.Columns.Add("Resistencia", "Resistencia");
            dgvInventarioJugador.Columns.Add("Costo", "Costo");


            foreach (var item in criaturas)
            {


                dgvInventarioJugador.Rows.Add(
                  item.IdCriatura,
                  item.Nombre,
                  item.Tipo,
                  item.Nivel,
                  item.Poder,
                  item.Resistencia,
                  item.Costo);
            }
            dgvInventarioJugador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventarioJugador.ReadOnly = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (dgvCriaturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una criatura disponible.");
                return;
            }
            // Obtener datos de la criatura seleccionada
            int idCriatura = Convert.ToInt32(dgvCriaturas.SelectedRows[0].Cells["IdCriatura"].Value);
            string tipo = dgvCriaturas.SelectedRows[0].Cells["Tipo"].Value.ToString();
            int costo = Convert.ToInt32(dgvCriaturas.SelectedRows[0].Cells["Costo"].Value);
            int poderBase = Convert.ToInt32(dgvCriaturas.SelectedRows[0].Cells["Poder"].Value);
            int resistenciaBase = Convert.ToInt32(dgvCriaturas.SelectedRows[0].Cells["Resistencia"].Value);


            CriaturaEntidad criatura = new CriaturaEntidad();
            criatura.IdCriatura = idCriatura;
            criatura.Tipo = tipo;
            criatura.Costo = costo;
            criatura.Poder = poderBase;
            criatura.Resistencia = resistenciaBase;
            CompraInventarioEntidad compra = new CompraInventarioEntidad();
            compra.Criatura = criatura;
            compra.Jugador = jugador;
            string json = JsonConvert.SerializeObject(compra);

            Task.Run(() =>
            {
                try
                {
                    string solicitud = $"REGISTRAR_INVENTARIO_JUGAGOR|{json}";
                    byte[] datos = Encoding.UTF8.GetBytes(solicitud);
                    stream.Write(datos, 0, datos.Length);

                    byte[] buffer = new byte[4096];
                    int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                    string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);

                    Invoke(new Action(() =>
                    {
                        if (respuesta.StartsWith("LISTA|"))
                        {

                            string[] partes = respuesta.Split('|');
                            string json = partes[1];
                            var respuestacompra = JsonConvert.DeserializeObject<RespuestaCompraEntidad>(json);

                            MessageBox.Show(respuestacompra.mensaje);
                        }
                        var inventarioActualizado = InventarioDatos.ObtenerPorJugador(jugador.IdJugador);
                        ActualizarGridInventarioJugador(inventarioActualizado);


                    }));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {

                        MessageBox.Show("Error al enviar solicitud: " + ex.Message);
                    }));
                }
            });


        }

        private void btnCrearEquipo_Click(object sender, EventArgs e)
        {
            int idJugador = this.IdJugador; 
            List<CriaturaEntidad> inventario = ObtenerInventarioDesdeGrid(); // método que extrae del DataGridView

            if (inventario == null || inventario.Count == 0)
            {
                MessageBox.Show("El jugador no tiene criaturas en su inventario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormEquipo equipoForm = new FormEquipo (idJugador, inventario);
            equipoForm.ShowDialog();
        }
        private List<CriaturaEntidad> ObtenerInventarioDesdeGrid()
        {
            var lista = new List<CriaturaEntidad>();

            foreach (DataGridViewRow row in dgvInventarioJugador.Rows)
            {
                if (row.IsNewRow) continue;

                lista.Add(new CriaturaEntidad
                {
                    IdCriatura = Convert.ToInt32(row.Cells["IdCriatura"].Value), 
                    Nombre = row.Cells["Nombre"].Value.ToString(),
                    Tipo = row.Cells["Tipo"].Value.ToString()
                });
            }

            return lista;
        }

    }
}
