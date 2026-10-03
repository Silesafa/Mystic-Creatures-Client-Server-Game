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
using AccesoDatos;
using Logica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServidorTCP
{
    public partial class FormJugador : Form
    {
        public FormJugador()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreJugador.Text;
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            DateTime nacimiento = dtpFechaNacimiento.Value;

            if (!int.TryParse(txtIdJugador.Text, out int idJugador))
            {
                MessageBox.Show("El IdJugador debe ser un número entero.");
                return;
            }


            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Todos los campos deben estar completos.");
                return;
            }

            // Validación de edad
            if (!JugadorLogica.ValidarEdad(nacimiento))
            {
                MessageBox.Show("El jugador debe tener al menos 10 años.");
                return;
            }

            try
            {
                JugadorEntidad jugador = new JugadorEntidad
                {
                    NombreJugador = nombre,
                    FechaNacimiento = nacimiento,
                    Nivel = 1,
                    Cristales = 100,
                    Usuario = usuario,
                    Password = password
                };

                var datos = new JugadorDatos();
                bool exito = datos.AgregarJugador(jugador, out string mensaje);
                MessageBox.Show(mensaje);

                if (exito)
                {
                    LimpiarCampos();
                    ActualizarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }


        private void ActualizarGrid()
        {
            var datos = new JugadorDatos();
            List<JugadorEntidad> jugadores = datos.ObtenerJugadores();

            dgvRegistConsulJugadores.DataSource = null;
            dgvRegistConsulJugadores.Columns.Clear();
            dgvRegistConsulJugadores.AutoGenerateColumns = true;
            dgvRegistConsulJugadores.DataSource = jugadores;
        }


        private void LimpiarCampos()
        {
            // txtIdJugador.Clear(); // Se omite porque no se usa
            txtNombreJugador.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            txtNombreJugador.Focus();
        }

        private void btnVerJugadores_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }
    }
}

