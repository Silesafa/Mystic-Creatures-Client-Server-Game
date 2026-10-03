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
    partial class FormCriatura
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
            lbRegistConsulCriaturas = new Label();
            lbIdCriatura = new Label();
            lbNombreCriatura = new Label();
            lbTipo = new Label();
            lbNivel = new Label();
            lbPoderCriatura = new Label();
            lbCosto = new Label();
            lbResistencia = new Label();
            txtIdCriatura = new TextBox();
            txtNombreCriatura = new TextBox();
            cbTipoCriatura = new ComboBox();
            txtResitencia = new TextBox();
            txtCosto = new TextBox();
            txtPoderCriatura = new TextBox();
            btnRegistrar = new Button();
            btnSalir = new Button();
            dgvCriaturas = new DataGridView();
            txtNivelCriatura = new TextBox();
            btnVerCriaturas = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCriaturas).BeginInit();
            SuspendLayout();
            // 
            // lbRegistConsulCriaturas
            // 
            lbRegistConsulCriaturas.AutoSize = true;
            lbRegistConsulCriaturas.Location = new Point(264, 11);
            lbRegistConsulCriaturas.Name = "lbRegistConsulCriaturas";
            lbRegistConsulCriaturas.Size = new Size(248, 25);
            lbRegistConsulCriaturas.TabIndex = 0;
            lbRegistConsulCriaturas.Text = "Registrar y consultar criaturas ";
            // 
            // lbIdCriatura
            // 
            lbIdCriatura.AutoSize = true;
            lbIdCriatura.Location = new Point(64, 80);
            lbIdCriatura.Name = "lbIdCriatura";
            lbIdCriatura.Size = new Size(94, 25);
            lbIdCriatura.TabIndex = 1;
            lbIdCriatura.Text = "Id Criatura";
            // 
            // lbNombreCriatura
            // 
            lbNombreCriatura.AutoSize = true;
            lbNombreCriatura.Location = new Point(64, 136);
            lbNombreCriatura.Name = "lbNombreCriatura";
            lbNombreCriatura.Size = new Size(144, 25);
            lbNombreCriatura.TabIndex = 2;
            lbNombreCriatura.Text = "Nombre Criatura";
            lbNombreCriatura.Click += lbNombreCriatura_Click;
            // 
            // lbTipo
            // 
            lbTipo.AutoSize = true;
            lbTipo.Location = new Point(64, 190);
            lbTipo.Name = "lbTipo";
            lbTipo.Size = new Size(113, 25);
            lbTipo.TabIndex = 3;
            lbTipo.Text = "Tipo Criatura";
            lbTipo.Click += lbTipo_Click;
            // 
            // lbNivel
            // 
            lbNivel.AutoSize = true;
            lbNivel.Location = new Point(64, 240);
            lbNivel.Name = "lbNivel";
            lbNivel.Size = new Size(117, 25);
            lbNivel.TabIndex = 4;
            lbNivel.Text = "Nivel Criatura";
            // 
            // lbPoderCriatura
            // 
            lbPoderCriatura.AutoSize = true;
            lbPoderCriatura.Location = new Point(516, 80);
            lbPoderCriatura.Name = "lbPoderCriatura";
            lbPoderCriatura.Size = new Size(124, 25);
            lbPoderCriatura.TabIndex = 5;
            lbPoderCriatura.Text = "Poder Criatura";
            // 
            // lbCosto
            // 
            lbCosto.AutoSize = true;
            lbCosto.Location = new Point(516, 190);
            lbCosto.Name = "lbCosto";
            lbCosto.Size = new Size(59, 25);
            lbCosto.TabIndex = 6;
            lbCosto.Text = "Costo";
            // 
            // lbResistencia
            // 
            lbResistencia.AutoSize = true;
            lbResistencia.Location = new Point(516, 136);
            lbResistencia.Name = "lbResistencia";
            lbResistencia.Size = new Size(97, 25);
            lbResistencia.TabIndex = 7;
            lbResistencia.Text = "Resistencia";
            // 
            // txtIdCriatura
            // 
            txtIdCriatura.Location = new Point(241, 76);
            txtIdCriatura.Margin = new Padding(3, 4, 3, 4);
            txtIdCriatura.Name = "txtIdCriatura";
            txtIdCriatura.Size = new Size(198, 31);
            txtIdCriatura.TabIndex = 8;
            // 
            // txtNombreCriatura
            // 
            txtNombreCriatura.Location = new Point(241, 136);
            txtNombreCriatura.Margin = new Padding(3, 4, 3, 4);
            txtNombreCriatura.Name = "txtNombreCriatura";
            txtNombreCriatura.Size = new Size(198, 31);
            txtNombreCriatura.TabIndex = 9;
            // 
            // cbTipoCriatura
            // 
            cbTipoCriatura.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoCriatura.FormattingEnabled = true;
            cbTipoCriatura.Items.AddRange(new object[] { "Agua", "Tierra", "Aire", "Fuego" });
            cbTipoCriatura.Location = new Point(237, 186);
            cbTipoCriatura.Margin = new Padding(3, 4, 3, 4);
            cbTipoCriatura.Name = "cbTipoCriatura";
            cbTipoCriatura.Size = new Size(202, 33);
            cbTipoCriatura.TabIndex = 10;
            // 
            // txtResitencia
            // 
            txtResitencia.Location = new Point(677, 136);
            txtResitencia.Margin = new Padding(3, 4, 3, 4);
            txtResitencia.Name = "txtResitencia";
            txtResitencia.Size = new Size(175, 31);
            txtResitencia.TabIndex = 13;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(677, 190);
            txtCosto.Margin = new Padding(3, 4, 3, 4);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(175, 31);
            txtCosto.TabIndex = 14;
            // 
            // txtPoderCriatura
            // 
            txtPoderCriatura.Location = new Point(677, 80);
            txtPoderCriatura.Margin = new Padding(3, 4, 3, 4);
            txtPoderCriatura.Name = "txtPoderCriatura";
            txtPoderCriatura.Size = new Size(175, 31);
            txtPoderCriatura.TabIndex = 15;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(203, 311);
            btnRegistrar.Margin = new Padding(3, 4, 3, 4);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(141, 62);
            btnRegistrar.TabIndex = 16;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(677, 311);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(137, 62);
            btnSalir.TabIndex = 17;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += button2_Click;
            // 
            // dgvCriaturas
            // 
            dgvCriaturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCriaturas.Location = new Point(-2, 405);
            dgvCriaturas.Margin = new Padding(3, 4, 3, 4);
            dgvCriaturas.Name = "dgvCriaturas";
            dgvCriaturas.RowHeadersWidth = 62;
            dgvCriaturas.RowTemplate.Height = 28;
            dgvCriaturas.Size = new Size(1098, 251);
            dgvCriaturas.TabIndex = 18;
            // 
            // txtNivelCriatura
            // 
            txtNivelCriatura.Location = new Point(237, 237);
            txtNivelCriatura.Name = "txtNivelCriatura";
            txtNivelCriatura.Size = new Size(202, 31);
            txtNivelCriatura.TabIndex = 19;
            // 
            // btnVerCriaturas
            // 
            btnVerCriaturas.Location = new Point(444, 311);
            btnVerCriaturas.Name = "btnVerCriaturas";
            btnVerCriaturas.Size = new Size(131, 62);
            btnVerCriaturas.TabIndex = 20;
            btnVerCriaturas.Text = "Ver";
            btnVerCriaturas.UseVisualStyleBackColor = true;
            btnVerCriaturas.Click += btnVerCriaturas_Click;
            // 
            // FormCriatura
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 654);
            Controls.Add(btnVerCriaturas);
            Controls.Add(txtNivelCriatura);
            Controls.Add(dgvCriaturas);
            Controls.Add(btnSalir);
            Controls.Add(btnRegistrar);
            Controls.Add(txtPoderCriatura);
            Controls.Add(txtCosto);
            Controls.Add(txtResitencia);
            Controls.Add(cbTipoCriatura);
            Controls.Add(txtNombreCriatura);
            Controls.Add(txtIdCriatura);
            Controls.Add(lbResistencia);
            Controls.Add(lbCosto);
            Controls.Add(lbPoderCriatura);
            Controls.Add(lbNivel);
            Controls.Add(lbTipo);
            Controls.Add(lbNombreCriatura);
            Controls.Add(lbIdCriatura);
            Controls.Add(lbRegistConsulCriaturas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormCriatura";
            Text = "FormCriatura";
            ((System.ComponentModel.ISupportInitialize)dgvCriaturas).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRegistConsulCriaturas;
        private System.Windows.Forms.Label lbIdCriatura;
        private System.Windows.Forms.Label lbNombreCriatura;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.Label lbNivel;
        private System.Windows.Forms.Label lbPoderCriatura;
        private System.Windows.Forms.Label lbCosto;
        private System.Windows.Forms.Label lbResistencia;
        private System.Windows.Forms.TextBox txtIdCriatura;
        private System.Windows.Forms.TextBox txtNombreCriatura;
        private System.Windows.Forms.TextBox txtResitencia;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtPoderCriatura;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvCriaturas;
        private TextBox txtNivelCriatura;
        protected ComboBox cbTipoCriatura;
        private Button btnVerCriaturas;
    }
}