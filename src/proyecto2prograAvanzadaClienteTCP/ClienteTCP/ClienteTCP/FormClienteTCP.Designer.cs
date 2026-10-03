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


namespace ClienteTCP
{
    partial class FormClienteTCP
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            txtEstadoServidor = new TextBox();
            lblUsuario = new Label();
            lblRespuesta = new Label();
            lblEstado = new Label();
            btnSalir = new Button();
            btnConectar = new Button();
            lblNombreJugador = new Label();
            txtNombreJugador = new TextBox();
            btnRegistConsultCriaturas = new Button();
            btnRegistConsultBatalla = new Button();
            btnConsultas = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(232, 9);
            label1.Name = "label1";
            label1.Size = new Size(328, 25);
            label1.TabIndex = 0;
            label1.Text = "Bienvenido al Juego de Criaturas Miticas";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(35, 88);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(168, 31);
            txtUsuario.TabIndex = 1;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(287, 86);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(183, 31);
            txtContrasena.TabIndex = 2;
            // 
            // txtEstadoServidor
            // 
            txtEstadoServidor.Location = new Point(566, 86);
            txtEstadoServidor.Name = "txtEstadoServidor";
            txtEstadoServidor.Size = new Size(178, 31);
            txtEstadoServidor.TabIndex = 3;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(76, 45);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(72, 25);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario";
            // 
            // lblRespuesta
            // 
            lblRespuesta.AutoSize = true;
            lblRespuesta.Location = new Point(332, 45);
            lblRespuesta.Name = "lblRespuesta";
            lblRespuesta.Size = new Size(101, 25);
            lblRespuesta.TabIndex = 5;
            lblRespuesta.Text = "Contraseña";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(576, 47);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(137, 25);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado Servidor";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(35, 407);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(340, 58);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(35, 152);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(340, 48);
            btnConectar.TabIndex = 9;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // lblNombreJugador
            // 
            lblNombreJugador.AutoSize = true;
            lblNombreJugador.Location = new Point(391, 164);
            lblNombreJugador.Name = "lblNombreJugador";
            lblNombreJugador.Size = new Size(147, 25);
            lblNombreJugador.TabIndex = 10;
            lblNombreJugador.Text = "Nombre Jugador";
            // 
            // txtNombreJugador
            // 
            txtNombreJugador.Location = new Point(554, 158);
            txtNombreJugador.Name = "txtNombreJugador";
            txtNombreJugador.Size = new Size(224, 31);
            txtNombreJugador.TabIndex = 11;
            txtNombreJugador.TextChanged += txtNombreJugador_TextChanged;
            // 
            // btnRegistConsultCriaturas
            // 
            btnRegistConsultCriaturas.Location = new Point(35, 206);
            btnRegistConsultCriaturas.Name = "btnRegistConsultCriaturas";
            btnRegistConsultCriaturas.Size = new Size(340, 67);
            btnRegistConsultCriaturas.TabIndex = 12;
            btnRegistConsultCriaturas.Text = "Registrar y consultar Inventario de Criaturas de Jugador";
            btnRegistConsultCriaturas.UseVisualStyleBackColor = true;
            btnRegistConsultCriaturas.Click += btnRegistConsultCriaturas_Click;
            // 
            // btnRegistConsultBatalla
            // 
            btnRegistConsultBatalla.Location = new Point(35, 279);
            btnRegistConsultBatalla.Name = "btnRegistConsultBatalla";
            btnRegistConsultBatalla.Size = new Size(340, 64);
            btnRegistConsultBatalla.TabIndex = 13;
            btnRegistConsultBatalla.Text = "Registrar o iniciar Batalla";
            btnRegistConsultBatalla.UseVisualStyleBackColor = true;
            btnRegistConsultBatalla.Click += btnRegistConsultBatalla_Click;
            // 
            // btnConsultas
            // 
            btnConsultas.Location = new Point(35, 349);
            btnConsultas.Name = "btnConsultas";
            btnConsultas.Size = new Size(340, 52);
            btnConsultas.TabIndex = 14;
            btnConsultas.Text = "Consultas";
            btnConsultas.UseVisualStyleBackColor = true;
            btnConsultas.Click += btnConsultas_Click;
            // 
            // FormClienteTCP
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 585);
            Controls.Add(btnConsultas);
            Controls.Add(btnRegistConsultBatalla);
            Controls.Add(btnRegistConsultCriaturas);
            Controls.Add(txtNombreJugador);
            Controls.Add(lblNombreJugador);
            Controls.Add(btnConectar);
            Controls.Add(btnSalir);
            Controls.Add(lblEstado);
            Controls.Add(lblRespuesta);
            Controls.Add(lblUsuario);
            Controls.Add(txtEstadoServidor);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            Name = "FormClienteTCP";
            Text = "FormClienteTCP";
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private Label label1;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private TextBox txtEstadoServidor;
        private Label lblUsuario;
        private Label lblRespuesta;
        private Label lblEstado;
        private Button btnSalir;
        private Button btnConectar;
    
    private void btnEnviar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de envío aún no implementada.");
        }
        private Label lblNombreJugador;
        private TextBox txtNombreJugador;
        private Button btnRegistConsultCriaturas;
        private Button btnRegistConsultBatalla;
        private Button btnConsultas;
    }
}