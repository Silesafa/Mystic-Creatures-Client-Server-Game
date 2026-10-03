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
    partial class FormEquipo
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
            lbRegistrarEquipos = new Label();
            lbIdEquipo = new Label();
            lbIdJugador = new Label();
            lbIdCriatura1 = new Label();
            lbIdCriatura2 = new Label();
            lbdCriatura3 = new Label();
            btnRegistrarEquipo = new Button();
            btnSalir = new Button();
            dgvEquipo = new DataGridView();
            lblNombreEquipo = new Label();
            txtNombreEquipo = new TextBox();
            textBox1 = new TextBox();
            cmbCriatura1 = new ComboBox();
            cmbCriatura2 = new ComboBox();
            cmbCriatura3 = new ComboBox();
            txtIdJugador = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvEquipo).BeginInit();
            SuspendLayout();
            // 
            // lbRegistrarEquipos
            // 
            lbRegistrarEquipos.AutoSize = true;
            lbRegistrarEquipos.Location = new Point(262, -1);
            lbRegistrarEquipos.Name = "lbRegistrarEquipos";
            lbRegistrarEquipos.Size = new Size(241, 25);
            lbRegistrarEquipos.TabIndex = 0;
            lbRegistrarEquipos.Text = "Registrar y consultar Equipos";
            lbRegistrarEquipos.Click += label1_Click;
            // 
            // lbIdEquipo
            // 
            lbIdEquipo.AutoSize = true;
            lbIdEquipo.Location = new Point(51, 62);
            lbIdEquipo.Name = "lbIdEquipo";
            lbIdEquipo.Size = new Size(89, 25);
            lbIdEquipo.TabIndex = 1;
            lbIdEquipo.Text = "Id Equipo";
            // 
            // lbIdJugador
            // 
            lbIdJugador.AutoSize = true;
            lbIdJugador.Location = new Point(51, 104);
            lbIdJugador.Name = "lbIdJugador";
            lbIdJugador.Size = new Size(97, 25);
            lbIdJugador.TabIndex = 2;
            lbIdJugador.Text = "Id Jugador";
            // 
            // lbIdCriatura1
            // 
            lbIdCriatura1.AutoSize = true;
            lbIdCriatura1.Location = new Point(431, 59);
            lbIdCriatura1.Name = "lbIdCriatura1";
            lbIdCriatura1.Size = new Size(109, 25);
            lbIdCriatura1.TabIndex = 3;
            lbIdCriatura1.Text = "Id Criatura 1";
            // 
            // lbIdCriatura2
            // 
            lbIdCriatura2.AutoSize = true;
            lbIdCriatura2.Location = new Point(431, 103);
            lbIdCriatura2.Name = "lbIdCriatura2";
            lbIdCriatura2.Size = new Size(109, 25);
            lbIdCriatura2.TabIndex = 4;
            lbIdCriatura2.Text = "Id Criatura 2";
            // 
            // lbdCriatura3
            // 
            lbdCriatura3.AutoSize = true;
            lbdCriatura3.Location = new Point(431, 146);
            lbdCriatura3.Name = "lbdCriatura3";
            lbdCriatura3.Size = new Size(109, 25);
            lbdCriatura3.TabIndex = 5;
            lbdCriatura3.Text = "Id Criatura 3";
            // 
            // btnRegistrarEquipo
            // 
            btnRegistrarEquipo.Location = new Point(145, 235);
            btnRegistrarEquipo.Name = "btnRegistrarEquipo";
            btnRegistrarEquipo.Size = new Size(152, 37);
            btnRegistrarEquipo.TabIndex = 11;
            btnRegistrarEquipo.Text = "Registrar Equipo";
            btnRegistrarEquipo.UseVisualStyleBackColor = true;
            btnRegistrarEquipo.Click += btnRegistrar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(487, 233);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 39);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // dgvEquipo
            // 
            dgvEquipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipo.Location = new Point(12, 304);
            dgvEquipo.MultiSelect = false;
            dgvEquipo.Name = "dgvEquipo";
            dgvEquipo.RowHeadersWidth = 62;
            dgvEquipo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipo.Size = new Size(786, 225);
            dgvEquipo.TabIndex = 13;
            dgvEquipo.CellContentClick += dgvEquipo_CellContentClick;
            // 
            // lblNombreEquipo
            // 
            lblNombreEquipo.AutoSize = true;
            lblNombreEquipo.Location = new Point(12, 151);
            lblNombreEquipo.Name = "lblNombreEquipo";
            lblNombreEquipo.Size = new Size(168, 25);
            lblNombreEquipo.TabIndex = 17;
            lblNombreEquipo.Text = "Nombre del Equipo";
            // 
            // txtNombreEquipo
            // 
            txtNombreEquipo.Location = new Point(206, 150);
            txtNombreEquipo.Name = "txtNombreEquipo";
            txtNombreEquipo.Size = new Size(152, 31);
            txtNombreEquipo.TabIndex = 18;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(206, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 21;
            // 
            // cmbCriatura1
            // 
            cmbCriatura1.FormattingEnabled = true;
            cmbCriatura1.Location = new Point(584, 57);
            cmbCriatura1.Name = "cmbCriatura1";
            cmbCriatura1.Size = new Size(137, 33);
            cmbCriatura1.TabIndex = 22;
            // 
            // cmbCriatura2
            // 
            cmbCriatura2.FormattingEnabled = true;
            cmbCriatura2.Location = new Point(583, 104);
            cmbCriatura2.Name = "cmbCriatura2";
            cmbCriatura2.Size = new Size(138, 33);
            cmbCriatura2.TabIndex = 23;
            // 
            // cmbCriatura3
            // 
            cmbCriatura3.FormattingEnabled = true;
            cmbCriatura3.Location = new Point(581, 154);
            cmbCriatura3.Name = "cmbCriatura3";
            cmbCriatura3.Size = new Size(140, 33);
            cmbCriatura3.TabIndex = 24;
            // 
            // txtIdJugador
            // 
            txtIdJugador.Location = new Point(206, 101);
            txtIdJugador.Name = "txtIdJugador";
            txtIdJugador.Size = new Size(150, 31);
            txtIdJugador.TabIndex = 25;
            // 
            // FormEquipo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 531);
            Controls.Add(txtIdJugador);
            Controls.Add(cmbCriatura3);
            Controls.Add(cmbCriatura2);
            Controls.Add(cmbCriatura1);
            Controls.Add(textBox1);
            Controls.Add(txtNombreEquipo);
            Controls.Add(lblNombreEquipo);
            Controls.Add(dgvEquipo);
            Controls.Add(btnSalir);
            Controls.Add(btnRegistrarEquipo);
            Controls.Add(lbdCriatura3);
            Controls.Add(lbIdCriatura2);
            Controls.Add(lbIdCriatura1);
            Controls.Add(lbIdJugador);
            Controls.Add(lbIdEquipo);
            Controls.Add(lbRegistrarEquipos);
            Name = "FormEquipo";
            Text = "FormEquipo";
            ((System.ComponentModel.ISupportInitialize)dgvEquipo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbRegistrarEquipos;
        private Label lbIdEquipo;
        private Label lbIdJugador;
        private Label lbIdCriatura1;
        private Label lbIdCriatura2;
        private Label lbdCriatura3;
        private Button btnRegistrarEquipo;
        private Button btnSalir;
        private DataGridView dgvEquipo;
        private Label lblNombreEquipo;
        private TextBox txtNombreEquipo;
        private TextBox textBox1;
        private ComboBox cmbCriatura1;
        private ComboBox cmbCriatura2;
        private ComboBox cmbCriatura3;
        private TextBox txtIdJugador;
    }
}