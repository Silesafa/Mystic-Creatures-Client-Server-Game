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
    partial class FormBatalla
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
            btnInciarBatalla = new Button();
            btnVerBatallas = new Button();
            btnSalir = new Button();
            cmbEquipos = new ComboBox();
            lblEquipo = new Label();
            dgvRondas = new DataGridView();
            lblCriatura1 = new Label();
            lblCriatura2 = new Label();
            lblCriatura3 = new Label();
            txtCriatura1 = new TextBox();
            txtCriatura2 = new TextBox();
            txtCriatura3 = new TextBox();
            lblTituloBatalla = new Label();
            lblIdJugador = new Label();
            txtIdJugador = new TextBox();
            lblMejoras = new Label();
            lblGanador = new Label();
            lblCristales = new Label();
            pnlResumenFinal = new Panel();
            dgvBatallas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRondas).BeginInit();
            pnlResumenFinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBatallas).BeginInit();
            SuspendLayout();
            // 
            // btnInciarBatalla
            // 
            btnInciarBatalla.Location = new Point(41, 169);
            btnInciarBatalla.Name = "btnInciarBatalla";
            btnInciarBatalla.Size = new Size(179, 46);
            btnInciarBatalla.TabIndex = 0;
            btnInciarBatalla.Text = "Iniciar Batalla";
            btnInciarBatalla.UseVisualStyleBackColor = true;
            btnInciarBatalla.Click += btnInciarBatalla_Click;
            // 
            // btnVerBatallas
            // 
            btnVerBatallas.Location = new Point(304, 169);
            btnVerBatallas.Name = "btnVerBatallas";
            btnVerBatallas.Size = new Size(162, 46);
            btnVerBatallas.TabIndex = 1;
            btnVerBatallas.Text = "Ver Batallas";
            btnVerBatallas.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(541, 169);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(190, 46);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // cmbEquipos
            // 
            cmbEquipos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEquipos.FormattingEnabled = true;
            cmbEquipos.Location = new Point(192, 96);
            cmbEquipos.Name = "cmbEquipos";
            cmbEquipos.Size = new Size(148, 33);
            cmbEquipos.TabIndex = 3;
            cmbEquipos.SelectedIndexChanged += cmbEquipos_SelectedIndexChanged;
            // 
            // lblEquipo
            // 
            lblEquipo.AutoSize = true;
            lblEquipo.Location = new Point(31, 104);
            lblEquipo.Name = "lblEquipo";
            lblEquipo.Size = new Size(135, 25);
            lblEquipo.TabIndex = 4;
            lblEquipo.Text = "Escoger Equipo";
            // 
            // dgvRondas
            // 
            dgvRondas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRondas.Location = new Point(-1, 316);
            dgvRondas.Name = "dgvRondas";
            dgvRondas.RowHeadersWidth = 62;
            dgvRondas.Size = new Size(807, 205);
            dgvRondas.TabIndex = 5;
            // 
            // lblCriatura1
            // 
            lblCriatura1.AutoSize = true;
            lblCriatura1.Location = new Point(511, 32);
            lblCriatura1.Name = "lblCriatura1";
            lblCriatura1.Size = new Size(88, 25);
            lblCriatura1.TabIndex = 6;
            lblCriatura1.Text = "Criatura 1";
            // 
            // lblCriatura2
            // 
            lblCriatura2.AutoSize = true;
            lblCriatura2.Location = new Point(509, 74);
            lblCriatura2.Name = "lblCriatura2";
            lblCriatura2.Size = new Size(88, 25);
            lblCriatura2.TabIndex = 7;
            lblCriatura2.Text = "Criatura 2";
            // 
            // lblCriatura3
            // 
            lblCriatura3.AutoSize = true;
            lblCriatura3.Location = new Point(511, 119);
            lblCriatura3.Name = "lblCriatura3";
            lblCriatura3.Size = new Size(88, 25);
            lblCriatura3.TabIndex = 8;
            lblCriatura3.Text = "Criatura 3";
            // 
            // txtCriatura1
            // 
            txtCriatura1.Location = new Point(627, 29);
            txtCriatura1.Name = "txtCriatura1";
            txtCriatura1.ReadOnly = true;
            txtCriatura1.Size = new Size(134, 31);
            txtCriatura1.TabIndex = 9;
            // 
            // txtCriatura2
            // 
            txtCriatura2.Location = new Point(627, 78);
            txtCriatura2.Name = "txtCriatura2";
            txtCriatura2.ReadOnly = true;
            txtCriatura2.Size = new Size(134, 31);
            txtCriatura2.TabIndex = 10;
            // 
            // txtCriatura3
            // 
            txtCriatura3.Location = new Point(627, 121);
            txtCriatura3.Name = "txtCriatura3";
            txtCriatura3.ReadOnly = true;
            txtCriatura3.Size = new Size(134, 31);
            txtCriatura3.TabIndex = 11;
            // 
            // lblTituloBatalla
            // 
            lblTituloBatalla.AutoSize = true;
            lblTituloBatalla.Location = new Point(280, 9);
            lblTituloBatalla.Name = "lblTituloBatalla";
            lblTituloBatalla.Size = new Size(204, 25);
            lblTituloBatalla.TabIndex = 12;
            lblTituloBatalla.Text = "Registrar o iniciar batalla";
            // 
            // lblIdJugador
            // 
            lblIdJugador.AutoSize = true;
            lblIdJugador.Location = new Point(48, 42);
            lblIdJugador.Name = "lblIdJugador";
            lblIdJugador.Size = new Size(97, 25);
            lblIdJugador.TabIndex = 13;
            lblIdJugador.Text = "Id Jugador";
            // 
            // txtIdJugador
            // 
            txtIdJugador.Location = new Point(190, 48);
            txtIdJugador.Name = "txtIdJugador";
            txtIdJugador.Size = new Size(150, 31);
            txtIdJugador.TabIndex = 14;
            // 
            // lblMejoras
            // 
            lblMejoras.AutoSize = true;
            lblMejoras.Location = new Point(345, 24);
            lblMejoras.Name = "lblMejoras";
            lblMejoras.Size = new Size(75, 25);
            lblMejoras.TabIndex = 17;
            lblMejoras.Text = "Mejoras";
            // 
            // lblGanador
            // 
            lblGanador.AutoSize = true;
            lblGanador.Location = new Point(615, 24);
            lblGanador.Name = "lblGanador";
            lblGanador.Size = new Size(80, 25);
            lblGanador.TabIndex = 18;
            lblGanador.Text = "Ganador";
            // 
            // lblCristales
            // 
            lblCristales.AutoSize = true;
            lblCristales.Location = new Point(77, 24);
            lblCristales.Name = "lblCristales";
            lblCristales.Size = new Size(77, 25);
            lblCristales.TabIndex = 16;
            lblCristales.Text = "Cristales";
            // 
            // pnlResumenFinal
            // 
            pnlResumenFinal.Controls.Add(lblGanador);
            pnlResumenFinal.Controls.Add(lblCristales);
            pnlResumenFinal.Controls.Add(lblMejoras);
            pnlResumenFinal.Location = new Point(12, 232);
            pnlResumenFinal.Name = "pnlResumenFinal";
            pnlResumenFinal.Size = new Size(776, 78);
            pnlResumenFinal.TabIndex = 15;
            // 
            // dgvBatallas
            // 
            dgvBatallas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBatallas.Location = new Point(-1, 527);
            dgvBatallas.Name = "dgvBatallas";
            dgvBatallas.RowHeadersWidth = 62;
            dgvBatallas.Size = new Size(806, 195);
            dgvBatallas.TabIndex = 16;
            // 
            // FormBatalla
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 721);
            Controls.Add(dgvBatallas);
            Controls.Add(pnlResumenFinal);
            Controls.Add(txtIdJugador);
            Controls.Add(lblIdJugador);
            Controls.Add(dgvRondas);
            Controls.Add(lblTituloBatalla);
            Controls.Add(txtCriatura3);
            Controls.Add(txtCriatura2);
            Controls.Add(txtCriatura1);
            Controls.Add(lblCriatura3);
            Controls.Add(lblCriatura2);
            Controls.Add(lblCriatura1);
            Controls.Add(lblEquipo);
            Controls.Add(cmbEquipos);
            Controls.Add(btnSalir);
            Controls.Add(btnVerBatallas);
            Controls.Add(btnInciarBatalla);
            Name = "FormBatalla";
            Text = "FormBatalla";
            ((System.ComponentModel.ISupportInitialize)dgvRondas).EndInit();
            pnlResumenFinal.ResumeLayout(false);
            pnlResumenFinal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBatallas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInciarBatalla;
        private Button btnVerBatallas;
        private Button btnSalir;
        private ComboBox cmbEquipos;
        private Label lblEquipo;
        private DataGridView dgvRondas;
        private Label lblCriatura1;
        private Label lblCriatura2;
        private Label lblCriatura3;
        private TextBox txtCriatura1;
        private TextBox txtCriatura2;
        private TextBox txtCriatura3;
        private Label lblTituloBatalla;
        private Label lblIdJugador;
        private TextBox txtIdJugador;
        private Label lblMejoras;
        private Label lblGanador;
        private Label lblCristales;
        private Panel pnlResumenFinal;
        private DataGridView dgvBatallas;
    }
}