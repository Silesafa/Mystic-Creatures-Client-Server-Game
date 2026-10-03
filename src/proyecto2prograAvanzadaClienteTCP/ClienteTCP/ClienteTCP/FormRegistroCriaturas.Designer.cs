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
    partial class FormRegistroCriaturas
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
            btnConsultar = new Button();
            dgvCriaturas = new DataGridView();
            label1 = new Label();
            dgvInventarioJugador = new DataGridView();
            label2 = new Label();
            btnSalir = new Button();
            btnComprar = new Button();
            btnCrearEquipo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCriaturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventarioJugador).BeginInit();
            SuspendLayout();
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(37, 555);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.RightToLeft = RightToLeft.Yes;
            btnConsultar.Size = new Size(230, 61);
            btnConsultar.TabIndex = 0;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += button1_Click;
            // 
            // dgvCriaturas
            // 
            dgvCriaturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCriaturas.Location = new Point(1, 72);
            dgvCriaturas.Name = "dgvCriaturas";
            dgvCriaturas.RowHeadersWidth = 62;
            dgvCriaturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCriaturas.Size = new Size(508, 444);
            dgvCriaturas.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(156, 25);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 2;
            label1.Text = "Disponible";
            label1.Click += label1_Click;
            // 
            // dgvInventarioJugador
            // 
            dgvInventarioJugador.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventarioJugador.Location = new Point(548, 72);
            dgvInventarioJugador.Name = "dgvInventarioJugador";
            dgvInventarioJugador.RowHeadersWidth = 62;
            dgvInventarioJugador.Size = new Size(498, 444);
            dgvInventarioJugador.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(732, 25);
            label2.Name = "label2";
            label2.Size = new Size(191, 25);
            label2.TabIndex = 4;
            label2.Text = "Inventario Del Jugador";
            label2.Click += label2_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(817, 555);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(215, 61);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(307, 555);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(225, 61);
            btnComprar.TabIndex = 6;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += button1_Click_1;
            // 
            // btnCrearEquipo
            // 
            btnCrearEquipo.Location = new Point(579, 555);
            btnCrearEquipo.Name = "btnCrearEquipo";
            btnCrearEquipo.Size = new Size(195, 61);
            btnCrearEquipo.TabIndex = 7;
            btnCrearEquipo.Text = "Crear Equipo";
            btnCrearEquipo.UseVisualStyleBackColor = true;
            btnCrearEquipo.Click += btnCrearEquipo_Click;
            // 
            // FormRegistroCriaturas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 714);
            Controls.Add(btnCrearEquipo);
            Controls.Add(btnComprar);
            Controls.Add(btnSalir);
            Controls.Add(label2);
            Controls.Add(dgvInventarioJugador);
            Controls.Add(label1);
            Controls.Add(dgvCriaturas);
            Controls.Add(btnConsultar);
            Name = "FormRegistroCriaturas";
            Text = "FormRegistroCriaturas";
            ((System.ComponentModel.ISupportInitialize)dgvCriaturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventarioJugador).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConsultar;
        private DataGridView dgvCriaturas;
        private Label label1;
        private DataGridView dgvInventarioJugador;
        private Label label2;
        private Button btnSalir;
        private Button btnComprar;
        private Button btnCrearEquipo;
    }
}