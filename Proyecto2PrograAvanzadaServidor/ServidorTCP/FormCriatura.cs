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
using Logica;

namespace ServidorTCP
{
    public partial class FormCriatura : Form
    {
        public FormCriatura()
        {
            InitializeComponent();
        }

        private void lbNombreCriatura_Click(object sender, EventArgs e)
        {

        }

        private void lbTipo_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // cierra app
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se Validan los campos obligatorios que no esten en blanco o sean null
                if (string.IsNullOrWhiteSpace(txtIdCriatura.Text) ||
                    string.IsNullOrWhiteSpace(txtNombreCriatura.Text) ||
                    cbTipoCriatura.SelectedIndex == -1 ||                   //se utiliza un cbx para que usuario elija tipo
                    string.IsNullOrWhiteSpace(txtNivelCriatura.Text) ||
                    string.IsNullOrWhiteSpace(txtPoderCriatura.Text) ||
                    string.IsNullOrWhiteSpace(txtResitencia.Text) ||
                    string.IsNullOrWhiteSpace(txtCosto.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                    return;
                }

                // Convertir valores de txt ingresados por usuario a int 
                int id = int.Parse(txtIdCriatura.Text);          // int.Parse se usa para convertir de string a a int.
                string nombre = txtNombreCriatura.Text.Trim();
                string tipo = cbTipoCriatura.SelectedItem?.ToString() ?? "desconocido";
                int nivel = int.Parse(txtNivelCriatura.Text); ;
                int poder = int.Parse(txtPoderCriatura.Text);
                int resistencia = int.Parse(txtResitencia.Text);
                int costo = int.Parse(txtCosto.Text);

                // Se Valida costo según nivel
                if (!CriaturaLogica.ValidarCosto(nivel, costo))
                {
                    MessageBox.Show("El costo no corresponde al nivel seleccionado.");
                    return;
                }

                // Se crea criatura
                CriaturaEntidad criatura = new CriaturaEntidad
                {
                    IdCriatura = id,
                    Nombre = nombre,
                    Tipo = tipo,
                    Nivel = nivel,
                    Poder = poder,
                    Resistencia = resistencia,
                    Costo = costo
                };

                // Registro de criatura
                string mensaje;
                CriaturaLogica.AgregarCriatura(criatura, out mensaje);    //se llama a método CriaturasDatos de Acceso Datos

                MessageBox.Show(mensaje); //Muestra msj dependiendo de validación que esta dentro del método


                LimpiarCampos();    // método  limpia campos para ingresar nuevos datos
                ActualizarGrid();   // método  actualiza el data grip con datos

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:Favor salir del app y volver a ingresar valores " + ex.Message);
            }
        }

        private void ActualizarGrid()
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

            List<CriaturaEntidad> criaturas = CriaturasDatos.ObtenerCriaturas();  // obtenemos criaturas registradas de CriaturasDatos obteniendo
                                                                                  // un arreglo basado en CriaturaEntidad
            foreach (var item in criaturas)
            {
                string nivelDescripcion = CriaturaLogica.ObtenerNivelCriatura(item.Nivel); // traducimos nivel numérico ingresado a string

                dgvCriaturas.Rows.Add(
                  item.IdCriatura,
                  item.Nombre,
                  item.Tipo,
                  nivelDescripcion,
                  item.Poder,
                  item.Resistencia,
                  item.Costo);
            }

        }

        private void LimpiarCampos()
        {
            txtIdCriatura.Clear();
            txtNombreCriatura.Clear();
            txtPoderCriatura.Clear();
            txtResitencia.Clear();
            txtCosto.Clear();
            cbTipoCriatura.SelectedIndex = -1;
            txtNivelCriatura.Clear();
        }

        private void btnVerCriaturas_Click(object sender, EventArgs e)
        {
         ActualizarGrid();

        }
}





}


