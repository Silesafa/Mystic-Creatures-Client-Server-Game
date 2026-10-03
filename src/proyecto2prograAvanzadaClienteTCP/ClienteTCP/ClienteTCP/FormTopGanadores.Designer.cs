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


using System.Drawing;
using System.Windows.Forms;



namespace ClienteTCP




{
    public partial class FormTopGanadores :Form
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
            dgvTopGanadores = new DataGridView();
            lbTopGandores = new Label();
            btnConsultar = new Button();
            btnSalir = new Button();
            lblBatallasParticipadas = new Label();
            dgvBatallasParticipadas = new DataGridView();
            lblRondas = new Label();
            dgvRondasBatallaEspecifica = new DataGridView();
            lblCriaturasJugador = new Label();
            dgvInventarioCriaturasJugador = new DataGridView();
            lblIdbatallaConsultar = new Label();
            txtIdBatalla = new TextBox();
            lblIdjugador = new Label();
            txtIdJugadorConsulta = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTopGanadores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBatallasParticipadas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRondasBatallaEspecifica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventarioCriaturasJugador).BeginInit();
            SuspendLayout();
            // 
            // dgvTopGanadores
            // 
            dgvTopGanadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopGanadores.Location = new Point(0, 44);
            dgvTopGanadores.Name = "dgvTopGanadores";
            dgvTopGanadores.RowHeadersWidth = 62;
            dgvTopGanadores.Size = new Size(435, 325);
            dgvTopGanadores.TabIndex = 0;
            // 
            // lbTopGandores
            // 
            lbTopGandores.AutoSize = true;
            lbTopGandores.Location = new Point(69, 9);
            lbTopGandores.Name = "lbTopGandores";
            lbTopGandores.Size = new Size(180, 25);
            lbTopGandores.TabIndex = 1;
            lbTopGandores.Text = "Top 10 de ganadores";
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(48, 743);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(116, 40);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(807, 742);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(114, 42);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblBatallasParticipadas
            // 
            lblBatallasParticipadas.AutoSize = true;
            lblBatallasParticipadas.Location = new Point(631, 9);
            lblBatallasParticipadas.Name = "lblBatallasParticipadas";
            lblBatallasParticipadas.Size = new Size(172, 25);
            lblBatallasParticipadas.TabIndex = 4;
            lblBatallasParticipadas.Text = "Batallas participadas";
            lblBatallasParticipadas.Click += label1_Click;
            // 
            // dgvBatallasParticipadas
            // 
            dgvBatallasParticipadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBatallasParticipadas.Location = new Point(471, 44);
            dgvBatallasParticipadas.Name = "dgvBatallasParticipadas";
            dgvBatallasParticipadas.RowHeadersWidth = 62;
            dgvBatallasParticipadas.Size = new Size(465, 325);
            dgvBatallasParticipadas.TabIndex = 5;
            // 
            // lblRondas
            // 
            lblRondas.AutoSize = true;
            lblRondas.Location = new Point(163, 383);
            lblRondas.Name = "lblRondas";
            lblRondas.Size = new Size(71, 25);
            lblRondas.TabIndex = 6;
            lblRondas.Text = "Rondas";
            // 
            // dgvRondasBatallaEspecifica
            // 
            dgvRondasBatallaEspecifica.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRondasBatallaEspecifica.Location = new Point(0, 411);
            dgvRondasBatallaEspecifica.Name = "dgvRondasBatallaEspecifica";
            dgvRondasBatallaEspecifica.RowHeadersWidth = 62;
            dgvRondasBatallaEspecifica.Size = new Size(435, 310);
            dgvRondasBatallaEspecifica.TabIndex = 7;
            // 
            // lblCriaturasJugador
            // 
            lblCriaturasJugador.AutoSize = true;
            lblCriaturasJugador.Location = new Point(620, 383);
            lblCriaturasJugador.Name = "lblCriaturasJugador";
            lblCriaturasJugador.Size = new Size(160, 25);
            lblCriaturasJugador.TabIndex = 8;
            lblCriaturasJugador.Text = "Inventario Jugador";
            lblCriaturasJugador.Click += lblCriaturasJugador_Click;
            // 
            // dgvInventarioCriaturasJugador
            // 
            dgvInventarioCriaturasJugador.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventarioCriaturasJugador.Location = new Point(471, 411);
            dgvInventarioCriaturasJugador.Name = "dgvInventarioCriaturasJugador";
            dgvInventarioCriaturasJugador.RowHeadersWidth = 62;
            dgvInventarioCriaturasJugador.Size = new Size(465, 310);
            dgvInventarioCriaturasJugador.TabIndex = 9;
            // 
            // lblIdbatallaConsultar
            // 
            lblIdbatallaConsultar.AutoSize = true;
            lblIdbatallaConsultar.Location = new Point(282, 751);
            lblIdbatallaConsultar.Name = "lblIdbatallaConsultar";
            lblIdbatallaConsultar.Size = new Size(143, 25);
            lblIdbatallaConsultar.TabIndex = 12;
            lblIdbatallaConsultar.Text = "Batalla Consultar";
            // 
            // txtIdBatalla
            // 
            txtIdBatalla.Location = new Point(442, 745);
            txtIdBatalla.Name = "txtIdBatalla";
            txtIdBatalla.Size = new Size(150, 31);
            txtIdBatalla.TabIndex = 13;
            txtIdBatalla.TextChanged += txtIdBatalla_TextChanged;
            // 
            // lblIdjugador
            // 
            lblIdjugador.AutoSize = true;
            lblIdjugador.Location = new Point(291, 787);
            lblIdjugador.Name = "lblIdjugador";
            lblIdjugador.Size = new Size(97, 25);
            lblIdjugador.TabIndex = 14;
            lblIdjugador.Text = "Id Jugador";
            // 
            // txtIdJugadorConsulta
            // 
            txtIdJugadorConsulta.Location = new Point(442, 787);
            txtIdJugadorConsulta.Name = "txtIdJugadorConsulta";
            txtIdJugadorConsulta.Size = new Size(150, 31);
            txtIdJugadorConsulta.TabIndex = 15;
            // 
            // FormTopGanadores
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 833);
            Controls.Add(txtIdJugadorConsulta);
            Controls.Add(lblIdjugador);
            Controls.Add(txtIdBatalla);
            Controls.Add(lblIdbatallaConsultar);
            Controls.Add(dgvInventarioCriaturasJugador);
            Controls.Add(lblCriaturasJugador);
            Controls.Add(dgvRondasBatallaEspecifica);
            Controls.Add(lblRondas);
            Controls.Add(dgvBatallasParticipadas);
            Controls.Add(lblBatallasParticipadas);
            Controls.Add(btnSalir);
            Controls.Add(btnConsultar);
            Controls.Add(lbTopGandores);
            Controls.Add(dgvTopGanadores);
            Name = "FormTopGanadores";
            Text = "FormTopGanadores";
            ((System.ComponentModel.ISupportInitialize)dgvTopGanadores).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBatallasParticipadas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRondasBatallaEspecifica).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventarioCriaturasJugador).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTopGanadores;
        private Label lbTopGandores;
        private Button btnConsultar;
        private Button btnSalir;
        private Label lblBatallasParticipadas;
        private DataGridView dgvBatallasParticipadas;
        private Label lblRondas;
        private DataGridView dgvRondasBatallaEspecifica;
        private Label lblCriaturasJugador;
        private DataGridView dgvInventarioCriaturasJugador;
        private Label lblIdbatallaConsultar;
        private TextBox txtIdBatalla;
        private Label lblIdjugador;
        private TextBox txtIdJugadorConsulta;
    }
}