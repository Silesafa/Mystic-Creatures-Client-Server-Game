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

using Entidades;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace ClienteTCP
{
    public partial class FormTopGanadores : Form
    {
        private NetworkStream stream;

        private int idJugador;
        public FormTopGanadores(NetworkStream streamRecibido, int idJugadorConectado)
        {
            InitializeComponent();
            stream = streamRecibido;
            idJugador = idJugadorConectado;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

           

            ConsultarHistorial(); //metodo llama a consultar historial para llenar los dgvs
            
        }

        // Consulta 1: Top 10 ganadores
        private void ConsultarHistorial ()  
        {
            int idBatalla = 0;
            int idJugador = 0;

            if (string.IsNullOrEmpty(txtIdBatalla.Text))
            {
                idBatalla = 0;
            }
            else {
               idBatalla= Convert.ToInt32(txtIdBatalla.Text);
            }

            if (string.IsNullOrEmpty(txtIdJugadorConsulta.Text))
            {
                idJugador = 0;
            }
            else
            {
                idJugador = Convert.ToInt32(txtIdJugadorConsulta.Text);
            }

            string solicitud = $"CONSULTAR_HISTORIAL|{idJugador}|{idBatalla}";
            stream.Write(Encoding.UTF8.GetBytes(solicitud), 0, solicitud.Length);

            byte[] buffer = new byte[8192];
            int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
            string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);

            var historial = JsonConvert.DeserializeObject<HistorialEntidad>(respuesta);

            ActualizarGridJugador(historial.TopJugadores);
            ConsultarBatallasJugador(historial.BatallasPorJugador);
            ConsultarRondasBatalla(historial.RondasPorBatalla);
            ConsultarInventarioJugador(historial.ConsultarInventarioJugador);
        }


        // Consulta 2: Batallas participadas por jugador
        private void ConsultarBatallasJugador(List<BatallaEntidad>lista)
        {
            dgvBatallasParticipadas.Rows.Clear();
            dgvBatallasParticipadas.Columns.Clear();

            dgvBatallasParticipadas.Columns.Add("IdBatalla", "ID");
            dgvBatallasParticipadas.Columns.Add("IdEquipo1", "IdEquipo1");
            dgvBatallasParticipadas.Columns.Add("IdEquipo2", "IdEquipo2");
            dgvBatallasParticipadas.Columns.Add("Fecha", "Fecha");
            dgvBatallasParticipadas.Columns.Add("Ganador", "Ganador");
            dgvBatallasParticipadas.Columns.Add("EstadoBatalla", "EstadoBatalla");
           


         
            foreach (var b in lista)
            {
                dgvBatallasParticipadas.Rows.Add(b.IdBatalla, b.IdEquipo1,b.IdEquipo2, b.Fecha, b.Ganador, b.Estado);
            }
        }


        // Consulta 3: Rondas de una batalla específica
        private void ConsultarRondasBatalla(List<RondasEntidad>lista)
        {

            dgvRondasBatallaEspecifica.Rows.Clear();
            dgvRondasBatallaEspecifica.Columns.Clear();

            dgvRondasBatallaEspecifica.Columns.Add("IdRonda", "ID");
            dgvRondasBatallaEspecifica.Columns.Add("IdBatalla", "IdBatalla");
            dgvRondasBatallaEspecifica.Columns.Add("NumeroRonda", "NumeroRonda");
            dgvRondasBatallaEspecifica.Columns.Add("IdInventarioAtacante", "IdInventarioAtacante");
            dgvRondasBatallaEspecifica.Columns.Add("IdInventarioDefensor", "IdInventarioDefensor");
            dgvRondasBatallaEspecifica.Columns.Add("GanadorRonda", "GanadorRonda");

            dgvRondasBatallaEspecifica.Rows.Clear();
            foreach (var r in lista)
            {
                dgvRondasBatallaEspecifica.Rows.Add(r.IdRonda,r.IdBatalla, r.NumeroRonda, r.IdInventarioAtacante, r.IdInventarioDefensor, r.GanadorRonda);
            }
        }
        

        // Consulta 4: Criaturas por jugador
        private void ConsultarInventarioJugador(List<CriaturaEntidad>lista)
        {
            dgvInventarioCriaturasJugador.Rows.Clear();
            dgvInventarioCriaturasJugador.Columns.Clear();

            dgvInventarioCriaturasJugador.Columns.Add("IdCriatura", "ID");
            dgvInventarioCriaturasJugador.Columns.Add("Nombre", "Nombre");
            dgvInventarioCriaturasJugador.Columns.Add("Tipo", "Tipo");
            dgvInventarioCriaturasJugador.Columns.Add("Nivel", "Nivel");
            dgvInventarioCriaturasJugador.Columns.Add("Poder", "Poder");
            dgvInventarioCriaturasJugador.Columns.Add("Resistencia", "Resistencia");
            dgvInventarioCriaturasJugador.Columns.Add("Costo", "Costo");


            foreach (var c in lista)
            {
                dgvInventarioCriaturasJugador.Rows.Add(c.IdCriatura, c.Nombre, c.Tipo, c.Nivel, c.Poder, c.Resistencia, c.Costo);
            }
        }
        





        //private void ActualizarGridInventarioJugador(List<CriaturaEntidad> criaturas)
        //{
        //    dgvInventarioCriaturasJugador.Rows.Clear();
        //    dgvInventarioCriaturasJugador.Columns.Clear();

        //    dgvInventarioCriaturasJugador.Columns.Add("IdCriatura", "ID");
        //    dgvInventarioCriaturasJugador.Columns.Add("Nombre", "Nombre");
        //    dgvInventarioCriaturasJugador.Columns.Add("Tipo", "Tipo");
        //    dgvInventarioCriaturasJugador.Columns.Add("Nivel", "Nivel");
        //    dgvInventarioCriaturasJugador.Columns.Add("Poder", "Poder");
        //    dgvInventarioCriaturasJugador.Columns.Add("Resistencia", "Resistencia");
        //    dgvInventarioCriaturasJugador.Columns.Add("Costo", "Costo");

        //    foreach (var item in criaturas)
        //    {
        //        dgvInventarioCriaturasJugador.Rows.Add(
        //            item.IdCriatura,
        //            item.Nombre,
        //            item.Tipo,
        //            item.Nivel,
        //            item.Poder,
        //            item.Resistencia,
        //            item.Costo);
        //    }

        //    dgvInventarioCriaturasJugador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvInventarioCriaturasJugador.ReadOnly = true;
        //}
        private void ActualizarGridJugador(List<JugadorEntidad> jugadores)
        {
            dgvTopGanadores.Rows.Clear();
            dgvTopGanadores.Columns.Clear();

            dgvTopGanadores.Columns.Add("IdJugador", "ID");
            dgvTopGanadores.Columns.Add("Nombre", "Nombre");
            dgvTopGanadores.Columns.Add("Victorias", "Victorias");
            

            foreach (var item in jugadores)
            {
                dgvTopGanadores.Rows.Add(
                    item.IdJugador,
                    item.NombreJugador,
                    item.Victorias);
                    
            }

            dgvTopGanadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopGanadores.ReadOnly = true;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Este evento puede quedar vacío o eliminarse si no lo usás
        }

        private void lblCriaturasJugador_Click(object sender, EventArgs e)
        {

        }

        private void txtIdBatalla_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

