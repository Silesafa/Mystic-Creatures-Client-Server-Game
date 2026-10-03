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
    partial class FormInventarioCliente
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
            lblRegistConsulCriaturas = new Label();
            lblIdJugador = new Label();
            lblIdCriatura = new Label();
            lblPoder = new Label();
            lblResistencia = new Label();
            txtIdJugador = new TextBox();
            txtPoder = new TextBox();
            txtIdCriatura = new TextBox();
            txtResistencia = new TextBox();
            btnRegistrar = new Button();
            btnSalir = new Button();
            dgvInventario = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // lblRegistConsulCriaturas
            // 
            lblRegistConsulCriaturas.AutoSize = true;
            lblRegistConsulCriaturas.Location = new Point(228, 9);
            lblRegistConsulCriaturas.Name = "lblRegistConsulCriaturas";
            lblRegistConsulCriaturas.Size = new Size(335, 25);
            lblRegistConsulCriaturas.TabIndex = 0;
            lblRegistConsulCriaturas.Text = "Registrar y consultar criaturas de jugador";
            // 
            // lblIdJugador
            // 
            lblIdJugador.AutoSize = true;
            lblIdJugador.Location = new Point(49, 78);
            lblIdJugador.Name = "lblIdJugador";
            lblIdJugador.Size = new Size(97, 25);
            lblIdJugador.TabIndex = 1;
            lblIdJugador.Text = "Id Jugador";
            // 
            // lblIdCriatura
            // 
            lblIdCriatura.AutoSize = true;
            lblIdCriatura.Location = new Point(49, 137);
            lblIdCriatura.Name = "lblIdCriatura";
            lblIdCriatura.Size = new Size(94, 25);
            lblIdCriatura.TabIndex = 2;
            lblIdCriatura.Text = "Id Criatura";
            // 
            // lblPoder
            // 
            lblPoder.AutoSize = true;
            lblPoder.Location = new Point(385, 73);
            lblPoder.Name = "lblPoder";
            lblPoder.Size = new Size(58, 25);
            lblPoder.TabIndex = 3;
            lblPoder.Text = "Poder";
            // 
            // lblResistencia
            // 
            lblResistencia.AutoSize = true;
            lblResistencia.Location = new Point(385, 139);
            lblResistencia.Name = "lblResistencia";
            lblResistencia.Size = new Size(97, 25);
            lblResistencia.TabIndex = 4;
            lblResistencia.Text = "Resistencia";
            // 
            // txtIdJugador
            // 
            txtIdJugador.Location = new Point(180, 75);
            txtIdJugador.Name = "txtIdJugador";
            txtIdJugador.Size = new Size(163, 31);
            txtIdJugador.TabIndex = 5;
            // 
            // txtPoder
            // 
            txtPoder.Location = new Point(505, 67);
            txtPoder.Name = "txtPoder";
            txtPoder.Size = new Size(195, 31);
            txtPoder.TabIndex = 6;
            // 
            // txtIdCriatura
            // 
            txtIdCriatura.Location = new Point(180, 133);
            txtIdCriatura.Name = "txtIdCriatura";
            txtIdCriatura.Size = new Size(163, 31);
            txtIdCriatura.TabIndex = 7;
            // 
            // txtResistencia
            // 
            txtResistencia.Location = new Point(505, 131);
            txtResistencia.Name = "txtResistencia";
            txtResistencia.Size = new Size(195, 31);
            txtResistencia.TabIndex = 8;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(180, 204);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(183, 44);
            btnRegistrar.TabIndex = 9;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(441, 200);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(174, 48);
            btnSalir.TabIndex = 10;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += button2_Click;
            // 
            // dgvInventario
            // 
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(0, 275);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.RowHeadersWidth = 62;
            dgvInventario.Size = new Size(861, 275);
            dgvInventario.TabIndex = 11;
            // 
            // FormInventarioCliente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 549);
            Controls.Add(dgvInventario);
            Controls.Add(btnSalir);
            Controls.Add(btnRegistrar);
            Controls.Add(txtResistencia);
            Controls.Add(txtIdCriatura);
            Controls.Add(txtPoder);
            Controls.Add(txtIdJugador);
            Controls.Add(lblResistencia);
            Controls.Add(lblPoder);
            Controls.Add(lblIdCriatura);
            Controls.Add(lblIdJugador);
            Controls.Add(lblRegistConsulCriaturas);
            Name = "FormInventarioCliente";
            Text = "FormInventarioCliente";
            Load += FormInventarioCliente_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegistConsulCriaturas;
        private Label lblIdJugador;
        private Label lblIdCriatura;
        private Label lblPoder;
        private Label lblResistencia;
        private TextBox txtIdJugador;
        private TextBox txtPoder;
        private TextBox txtIdCriatura;
        private TextBox txtResistencia;
        private Button btnRegistrar;
        private Button btnSalir;
        private DataGridView dgvInventario;
    }
}