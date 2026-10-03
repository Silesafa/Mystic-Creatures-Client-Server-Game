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
   public partial class FormJugador :Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbRegistConsulJugadores = new Label();
            lbNombreJugador = new Label();
            lbFechaNacimiento = new Label();
            lbNivel = new Label();
            lbCristales = new Label();
            txtNombreJugador = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            txtNivel = new TextBox();
            txtcristales = new TextBox();
            dgvRegistConsulJugadores = new DataGridView();
            btnRegistrar = new Button();
            btnSalir = new Button();
            lblUsuario = new Label();
            lblpassword = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            lblIdJugador = new Label();
            txtIdJugador = new TextBox();
            btnVerJugadores = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRegistConsulJugadores).BeginInit();
            SuspendLayout();
            // 
            // lbRegistConsulJugadores
            // 
            lbRegistConsulJugadores.AutoSize = true;
            lbRegistConsulJugadores.Location = new Point(352, 19);
            lbRegistConsulJugadores.Name = "lbRegistConsulJugadores";
            lbRegistConsulJugadores.Size = new Size(256, 25);
            lbRegistConsulJugadores.TabIndex = 1;
            lbRegistConsulJugadores.Text = "Registrar y consultar jugadores";
            // 
            // lbNombreJugador
            // 
            lbNombreJugador.AutoSize = true;
            lbNombreJugador.Location = new Point(73, 118);
            lbNombreJugador.Name = "lbNombreJugador";
            lbNombreJugador.Size = new Size(147, 25);
            lbNombreJugador.TabIndex = 2;
            lbNombreJugador.Text = "Nombre Jugador";
            // 
            // lbFechaNacimiento
            // 
            lbFechaNacimiento.AutoSize = true;
            lbFechaNacimiento.Location = new Point(73, 238);
            lbFechaNacimiento.Name = "lbFechaNacimiento";
            lbFechaNacimiento.Size = new Size(182, 25);
            lbFechaNacimiento.TabIndex = 3;
            lbFechaNacimiento.Text = "Fecha de  Nacimiento";
            // 
            // lbNivel
            // 
            lbNivel.AutoSize = true;
            lbNivel.Location = new Point(74, 281);
            lbNivel.Name = "lbNivel";
            lbNivel.Size = new Size(51, 25);
            lbNivel.TabIndex = 4;
            lbNivel.Text = "Nivel";
            // 
            // lbCristales
            // 
            lbCristales.AutoSize = true;
            lbCristales.Location = new Point(69, 329);
            lbCristales.Name = "lbCristales";
            lbCristales.Size = new Size(77, 25);
            lbCristales.TabIndex = 5;
            lbCristales.Text = "Cristales";
            // 
            // txtNombreJugador
            // 
            txtNombreJugador.Location = new Point(361, 104);
            txtNombreJugador.Margin = new Padding(3, 4, 3, 4);
            txtNombreJugador.Name = "txtNombreJugador";
            txtNombreJugador.Size = new Size(256, 31);
            txtNombreJugador.TabIndex = 8;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(358, 233);
            dtpFechaNacimiento.Margin = new Padding(3, 4, 3, 4);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(256, 31);
            dtpFechaNacimiento.TabIndex = 9;
            // 
            // txtNivel
            // 
            txtNivel.Location = new Point(358, 281);
            txtNivel.Margin = new Padding(3, 4, 3, 4);
            txtNivel.Name = "txtNivel";
            txtNivel.Size = new Size(256, 31);
            txtNivel.TabIndex = 10;
            // 
            // txtcristales
            // 
            txtcristales.Location = new Point(355, 329);
            txtcristales.Margin = new Padding(3, 4, 3, 4);
            txtcristales.Name = "txtcristales";
            txtcristales.Size = new Size(256, 31);
            txtcristales.TabIndex = 11;
            // 
            // dgvRegistConsulJugadores
            // 
            dgvRegistConsulJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistConsulJugadores.Location = new Point(-4, 512);
            dgvRegistConsulJugadores.Margin = new Padding(3, 4, 3, 4);
            dgvRegistConsulJugadores.Name = "dgvRegistConsulJugadores";
            dgvRegistConsulJugadores.RowHeadersWidth = 62;
            dgvRegistConsulJugadores.RowTemplate.Height = 28;
            dgvRegistConsulJugadores.Size = new Size(1000, 382);
            dgvRegistConsulJugadores.TabIndex = 13;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(164, 429);
            btnRegistrar.Margin = new Padding(3, 4, 3, 4);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(166, 44);
            btnRegistrar.TabIndex = 14;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnGuardar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(651, 429);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(184, 44);
            btnSalir.TabIndex = 15;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(74, 159);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(72, 25);
            lblUsuario.TabIndex = 16;
            lblUsuario.Text = "Usuario";
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.Location = new Point(74, 197);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(87, 25);
            lblpassword.TabIndex = 17;
            lblpassword.Text = "Password";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(361, 142);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(253, 31);
            txtUsuario.TabIndex = 18;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(358, 182);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(253, 31);
            txtPassword.TabIndex = 19;
            // 
            // lblIdJugador
            // 
            lblIdJugador.AutoSize = true;
            lblIdJugador.Location = new Point(73, 72);
            lblIdJugador.Name = "lblIdJugador";
            lblIdJugador.Size = new Size(97, 25);
            lblIdJugador.TabIndex = 20;
            lblIdJugador.Text = "Id Jugador";
            // 
            // txtIdJugador
            // 
            txtIdJugador.Location = new Point(360, 65);
            txtIdJugador.Name = "txtIdJugador";
            txtIdJugador.Size = new Size(254, 31);
            txtIdJugador.TabIndex = 21;
            // 
            // btnVerJugadores
            // 
            btnVerJugadores.Location = new Point(438, 429);
            btnVerJugadores.Name = "btnVerJugadores";
            btnVerJugadores.Size = new Size(155, 44);
            btnVerJugadores.TabIndex = 22;
            btnVerJugadores.Text = "Ver";
            btnVerJugadores.UseVisualStyleBackColor = true;
            btnVerJugadores.Click += btnVerJugadores_Click;
            // 
            // FormJugador
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 889);
            Controls.Add(btnVerJugadores);
            Controls.Add(txtIdJugador);
            Controls.Add(lblIdJugador);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblpassword);
            Controls.Add(lblUsuario);
            Controls.Add(btnSalir);
            Controls.Add(btnRegistrar);
            Controls.Add(dgvRegistConsulJugadores);
            Controls.Add(txtcristales);
            Controls.Add(txtNivel);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtNombreJugador);
            Controls.Add(lbCristales);
            Controls.Add(lbNivel);
            Controls.Add(lbFechaNacimiento);
            Controls.Add(lbNombreJugador);
            Controls.Add(lbRegistConsulJugadores);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormJugador";
            Text = "FormJugador";
            ((System.ComponentModel.ISupportInitialize)dgvRegistConsulJugadores).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbRegistConsulJugadores;
        private System.Windows.Forms.Label lbNombreJugador;
        private System.Windows.Forms.Label lbFechaNacimiento;
        private System.Windows.Forms.Label lbNivel;
        private System.Windows.Forms.Label lbCristales;
        private System.Windows.Forms.TextBox txtNombreJugador;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TextBox txtNivel;
        private System.Windows.Forms.TextBox txtcristales;
        private System.Windows.Forms.DataGridView dgvRegistConsulJugadores;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnSalir;
        private Label lblUsuario;
        private Label lblpassword;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Label lblIdJugador;
        private TextBox txtIdJugador;
        private Button btnVerJugadores;
    }
}