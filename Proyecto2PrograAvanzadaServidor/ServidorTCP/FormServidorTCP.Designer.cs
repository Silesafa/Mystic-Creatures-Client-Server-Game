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
    partial class FormServidorTCP
    {
        private System.ComponentModel.IContainer components = null;

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
            BitacoraServidor = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtContador = new TextBox();
            button1 = new Button();
            button2 = new Button();
            btnRegistrarConsultCriaturas = new Button();
            btnRegistConsultJugadores = new Button();
            SuspendLayout();
            // 
            // BitacoraServidor
            // 
            BitacoraServidor.FormattingEnabled = true;
            BitacoraServidor.ItemHeight = 25;
            BitacoraServidor.Location = new Point(3, 70);
            BitacoraServidor.Name = "BitacoraServidor";
            BitacoraServidor.Size = new Size(795, 154);
            BitacoraServidor.TabIndex = 0;
            BitacoraServidor.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(298, 2);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 1;
            label1.Text = "Servidor TCP";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 42);
            label2.Name = "label2";
            label2.Size = new Size(173, 25);
            label2.TabIndex = 2;
            label2.Text = "Bitacora del servidor";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 246);
            label3.Name = "label3";
            label3.Size = new Size(153, 25);
            label3.TabIndex = 3;
            label3.Text = "Contador Clientes";
            label3.Click += label3_Click;
            // 
            // txtContador
            // 
            txtContador.Location = new Point(201, 240);
            txtContador.Name = "txtContador";
            txtContador.Size = new Size(115, 31);
            txtContador.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(61, 308);
            button1.Name = "button1";
            button1.Size = new Size(184, 52);
            button1.TabIndex = 5;
            button1.Text = "Iniciar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(532, 311);
            button2.Name = "button2";
            button2.Size = new Size(190, 47);
            button2.TabIndex = 6;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnRegistrarConsultCriaturas
            // 
            btnRegistrarConsultCriaturas.Location = new Point(425, 392);
            btnRegistrarConsultCriaturas.Name = "btnRegistrarConsultCriaturas";
            btnRegistrarConsultCriaturas.Size = new Size(282, 54);
            btnRegistrarConsultCriaturas.TabIndex = 7;
            btnRegistrarConsultCriaturas.Text = "Registrar y consultar Criaturas.";
            btnRegistrarConsultCriaturas.UseVisualStyleBackColor = true;
            btnRegistrarConsultCriaturas.Click += button3_Click;
            // 
            // btnRegistConsultJugadores
            // 
            btnRegistConsultJugadores.Location = new Point(61, 398);
            btnRegistConsultJugadores.Name = "btnRegistConsultJugadores";
            btnRegistConsultJugadores.Size = new Size(315, 48);
            btnRegistConsultJugadores.TabIndex = 8;
            btnRegistConsultJugadores.Text = "Registrar y consultar Jugadores";
            btnRegistConsultJugadores.UseVisualStyleBackColor = true;
            btnRegistConsultJugadores.Click += btnRegistConsultJugadores_Click;
            // 
            // FormServidorTCP
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(btnRegistConsultJugadores);
            Controls.Add(btnRegistrarConsultCriaturas);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtContador);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BitacoraServidor);
            Name = "FormServidorTCP";
            Text = "FormServidorTCP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox BitacoraServidor;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtContador;
        private Button button1;
        private Button button2;
    
     private ServidorTCP servidor;

        public void ActualizarBitacora(string mensaje)
        {
            if (InvokeRequired)
                Invoke(new Action(() => BitacoraServidor.Items.Add(mensaje)));
            else
                BitacoraServidor.Items.Add(mensaje);
        }

        public void ActualizarContador(int cantidad)
        {
            if (InvokeRequired)
                Invoke(new Action(() => txtContador.Text = cantidad.ToString()));
            else
                txtContador.Text = cantidad.ToString();
        }
        private Button btnRegistrarConsultCriaturas;
        private Button btnRegistConsultJugadores;
    }

    }