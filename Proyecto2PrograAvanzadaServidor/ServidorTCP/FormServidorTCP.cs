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


namespace ServidorTCP
{
    public partial class FormServidorTCP : Form
    {
        public FormServidorTCP()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }

        private void button1_Click(object sender, EventArgs e)
        {

            servidor = new ServidorTCP(this);                //se incia el servidor
            servidor.Iniciar();
            ActualizarBitacora("Servidor iniciado...");
        }

        private void button3_Click(object sender, EventArgs e)
        {
             
            FormCriatura CriaturaForm = new FormCriatura();    //abre form de registro criatura
            CriaturaForm.Show();
        }

        private void btnRegistConsultJugadores_Click(object sender, EventArgs e)
        {
            FormJugador jugadorForm = new FormJugador();   //abre form de registro Jugador
            jugadorForm.Show();
        }
    }
}

