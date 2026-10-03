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


    public partial class FormBatalla : Form
    {
        private NetworkStream stream;
        private int idJugador;
        public FormBatalla(NetworkStream streamRecibido, int idJugadorRecibido)
        {
            InitializeComponent();
            stream = streamRecibido;
            idJugador = idJugadorRecibido;

            txtIdJugador.Text = idJugador.ToString();
            txtIdJugador.ReadOnly = true;

            CargarEquiposDelJugador();
        }

        private void EscucharRespuestaBatalla()  //escucha la respuesta de batalla
        {
            try
            {
                byte[] buffer = new byte[4096];
                int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);

                Invoke(new Action(() =>
                {
                    if (respuesta.StartsWith("ESPERA"))   //en espera si solo hay un jugador
                    {
                        MessageBox.Show("Esperando otro jugador para iniciar la batalla...");
                    }
                    else if (respuesta.StartsWith("BATALLA_INICIADA|")) //incia batalla cuando hay 2 jugadroes conectados
                    {
                        string[] partes = respuesta.Split('|');
                        int idBatalla = Convert.ToInt32(partes[1]);
                        MessageBox.Show($"¡Batalla iniciada! Código: {idBatalla}");

                    }
                    else if (respuesta.StartsWith("RONDA_FINALIZADA|")) //finaliza rondas
                    {
                        string[] partes = respuesta.Split('|');
                        var json =partes[1];      
                        var rondas = JsonConvert.DeserializeObject<List<RondasEntidad>>(json); //msj json recibido
                        ActualizarHistorialBatallas(rondas);                     
                    }
                    else
                    {
                        MessageBox.Show("Error al iniciar batalla. Intenta de nuevo.");
                    }
                }));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Error al comunicarse con el servidor: " + ex.Message);
                }));
            }
        }


        private void btnInciarBatalla_Click(object sender, EventArgs e)  //inicia batallas
        {
            if (cmbEquipos.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar un equipo válido.");
                return;
            }

            int idJugador = Convert.ToInt32(txtIdJugador.Text);
            int idEquipo = Convert.ToInt32(cmbEquipos.SelectedValue);

            string solicitud = $"INICIAR_BATALLA|{idJugador}|{idEquipo}";
            byte[] datos = Encoding.UTF8.GetBytes(solicitud);
            stream.Write(datos, 0, datos.Length);

            Task.Run(() => EscucharRespuestaBatalla());
        }

        private void MostrarRondasEnCurso(int idBatalla)
        {
            var rondas = RondasDatos.ObtenerPorBatalla(idBatalla);
            dgvRondas.Rows.Clear();

            foreach (var r in rondas)
            {
                dgvRondas.Rows.Add(r.IdRonda, r.IdInventarioAtacante, r.IdInventarioDefensor, r.GanadorRonda);
            }
        } 
        private void ActualizarHistorialBatallas(List <RondasEntidad> Ronda)
        {        
            dgvBatallas.Rows.Clear();        
            dgvBatallas.Columns.Clear();

            dgvBatallas.Columns.Add("IdRonda", "IdRonda");
            dgvBatallas.Columns.Add("IdBatalla", "IdBatalla");
            dgvBatallas.Columns.Add("IdInventarioAtacante", "IdInventarioAtacante");
            dgvBatallas.Columns.Add("IdInventarioDefensor", "IdInventarioDefensor");
            dgvBatallas.Columns.Add("GanadorRonda", "GanadorRonda");


            foreach (var b in Ronda)
            {
                dgvBatallas.Rows.Add(b.NumeroRonda,b.IdBatalla,b.IdInventarioAtacante,b.IdInventarioDefensor,b.GanadorRonda);
            }
        }
        private void MostrarResumenFinal(int idBatalla)  //actualiza datos despues de batalla
        {
            var resumen = BatallaDatos.ObtenerResumenBatalla(idBatalla);

            lblCristales.Text = $"Cristales ganados: {resumen.Cristales}";
            lblMejoras.Text = $"Mejoras aplicadas: {resumen.Mejoras}";
            lblGanador.Text = $"Ganador: Jugador {resumen.IdGanador}";
            pnlResumenFinal.Visible = true;
        }

        private void CargarEquiposDelJugador()  //metodo ccarga equipos del jugador
        {
            var equipos = EquipoDatos.ObtenerEquiposPorJugador(idJugador);

            cmbEquipos.DisplayMember = "NombreEquipo";
            cmbEquipos.ValueMember = "IdEquipo";
            cmbEquipos.DataSource = equipos;
            cmbEquipos.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbEquipos.SelectedIndexChanged += cmbEquipos_SelectedIndexChanged;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); //cierra pantalla
        }

        private void cmbEquipos_SelectedIndexChanged(object sender, EventArgs e)  //combo box para seleccionar euqipos cargados
        {
            if (cmbEquipos.SelectedItem is EquipoEntidad equipo)
            {
                EquipoDatos datos = new EquipoDatos();
                var criaturas = datos.ObtenerCriaturasDeEquipoArreglo(equipo.IdJugador, equipo.IdEquipo);


                txtCriatura1.Text = criaturas.Count > 0 ? criaturas[0].Nombre : "";
                txtCriatura2.Text = criaturas.Count > 1 ? criaturas[1].Nombre : "";
                txtCriatura3.Text = criaturas.Count > 2 ? criaturas[2].Nombre : "";
            }
        }
    }
}

