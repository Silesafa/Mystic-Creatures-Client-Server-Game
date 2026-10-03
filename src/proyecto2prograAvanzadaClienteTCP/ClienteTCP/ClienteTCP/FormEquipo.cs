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

namespace ClienteTCP
{
    public partial class FormEquipo : Form
    {
        private int IdJugador;
        private List<CriaturaEntidad> inventario;
        public FormEquipo(int idJugador, List<CriaturaEntidad> inventario)
        {
            InitializeComponent();
            this.IdJugador = idJugador;
            this.inventario = inventario ?? new List<CriaturaEntidad>();
            CargarOpcionesDeCriaturas();
            CargarEquiposDelJugador();

            txtIdJugador.Text = IdJugador.ToString();
            txtIdJugador.ReadOnly = true;
        }

        private void CargarOpcionesDeCriaturas()  // carga las opciones de criaturas que tiene el jugador con sus validaciones
        {
            // Valida y carga en ComboBox
            if (inventario.Count == 0)
            {
                MessageBox.Show("No hay criaturas disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Verifica contenido del inventario
            foreach (var c in inventario)
            {
                Console.WriteLine($"ID: {c.IdCriatura}, Nombre: {c.Nombre}");
            }

            cmbCriatura1.DataSource = new List<CriaturaEntidad>(inventario);
            cmbCriatura1.DisplayMember = "Nombre";
            cmbCriatura1.ValueMember = "IdCriatura";
            cmbCriatura1.SelectedIndex = 0;

            cmbCriatura2.DataSource = new List<CriaturaEntidad>(inventario);
            cmbCriatura2.DisplayMember = "Nombre";
            cmbCriatura2.ValueMember = "IdCriatura";
            cmbCriatura2.SelectedIndex = 0;

            cmbCriatura3.DataSource = new List<CriaturaEntidad>(inventario);
            cmbCriatura3.DisplayMember = "Nombre";
            cmbCriatura3.ValueMember = "IdCriatura";
            cmbCriatura3.SelectedIndex = 0;

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); //cierra ventana
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            //Valida nombre del equipo
            string nombreEquipo = txtNombreEquipo.Text.Trim();
            if (string.IsNullOrEmpty(nombreEquipo))
            {
                MessageBox.Show("Debes ingresar un nombre para el equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idJugador = this.IdJugador;
            int idCriatura1 = Convert.ToInt32(cmbCriatura1.SelectedValue);
            int idCriatura2 = Convert.ToInt32(cmbCriatura2.SelectedValue);
            int idCriatura3 = Convert.ToInt32(cmbCriatura3.SelectedValue);

            // Valida que las criaturas sean distintas
            if (idCriatura1 == idCriatura2 || idCriatura1 == idCriatura3 || idCriatura2 == idCriatura3)
            {
                MessageBox.Show("Las criaturas deben ser distintas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var criaturas = new HashSet<int> { idCriatura1, idCriatura2, idCriatura3 };
            if (criaturas.Count < 3)
            {
                MessageBox.Show("Las criaturas deben ser distintas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InventarioDatos inventarioDatos = new InventarioDatos();

            if (!inventarioDatos.ExisteInventario(idJugador, idCriatura1) ||
                !inventarioDatos.ExisteInventario(idJugador, idCriatura2) ||
                !inventarioDatos.ExisteInventario(idJugador, idCriatura3))
            {
                MessageBox.Show("Todas las criaturas deben estar en el inventario del jugador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            EquipoEntidad nuevoEquipo = new EquipoEntidad
            {


                IdJugador = idJugador,
                NombreEquipo = nombreEquipo,
                IdCriatura1 = idCriatura1,
                IdCriatura2 = idCriatura2,
                IdCriatura3 = idCriatura3
            };

            string mensaje;
            bool exito = EquipoDatos.RegistrarEquipo(nuevoEquipo, out mensaje);

            MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (exito)
            {
                CargarEquiposDelJugador();
            }
        }
        private void CargarEquiposDelJugador()
        {
            dgvEquipo.Rows.Clear();
            dgvEquipo.Columns.Clear();

            dgvEquipo.Columns.Add("IdEquipo", "ID Equipo");
            dgvEquipo.Columns.Add("IdJugador", "ID Jugador");
            dgvEquipo.Columns.Add("NombreEquipo", "Nombre");
            dgvEquipo.Columns.Add("Criatura1", "Criatura 1");
            dgvEquipo.Columns.Add("Criatura2", "Criatura 2");
            dgvEquipo.Columns.Add("Criatura3", "Criatura 3");



            int idJugador = this.IdJugador;
            var equipos = EquipoDatos.ObtenerEquiposPorJugador(idJugador);

            foreach (var eq in equipos)
            {
                EquipoDatos datos = new EquipoDatos();
                var criaturas = datos.ObtenerCriaturasDeEquipoArreglo(eq.IdJugador, eq.IdEquipo);

                string nombre1 = criaturas.Count > 0 ? criaturas[0].Nombre : "";
                string nombre2 = criaturas.Count > 1 ? criaturas[1].Nombre : "";
                string nombre3 = criaturas.Count > 2 ? criaturas[2].Nombre : "";

                dgvEquipo.Rows.Add(eq.IdEquipo, eq.IdJugador, eq.NombreEquipo, nombre1, nombre2, nombre3);

            }

            dgvEquipo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEquipo.ReadOnly = true;
        }





        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbIdJugador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvEquipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVerEquipos_Click(object sender, EventArgs e)
        {
            CargarEquiposDelJugador();
        }

        private void btnverEquipos_Click_1(object sender, EventArgs e)
        {

        }
    }
}

