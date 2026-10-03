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


using System.Net;
using System.Net.Sockets;

namespace ServidorTCP
{
    public class ServidorTCP
    {
        private TcpListener listener;
        private List<TcpClient> clientes = new List<TcpClient>();
        private FormServidorTCP form;
        private const int MAX_CONEXIONES = 8;

        public ServidorTCP(FormServidorTCP form)
        {
            this.form = form;
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 14100);
        }

        public void Iniciar()
        {
            listener.Start();
            Thread hiloEscucha = new Thread(EscucharClientes);
            hiloEscucha.IsBackground = true;
            hiloEscucha.Start();
            form.ActualizarBitacora("Servidor iniciado...");
        }

        private void EscucharClientes()
        {
            while (true)
            {
                try
                {
                    TcpClient cliente = listener.AcceptTcpClient();
                    if (clientes.Count < MAX_CONEXIONES)
                    {
                        clientes.Add(cliente);
                        form.ActualizarContador(clientes.Count);
                        form.ActualizarBitacora("Cliente conectado.");

                        ClienteHandler handler = new ClienteHandler(cliente, form, this);
                        Thread hiloCliente = new Thread(handler.Procesar);
                        hiloCliente.IsBackground = true;
                        hiloCliente.Start();
                    }
                    else
                    {
                        form.ActualizarBitacora("Conexión rechazada: máximo de clientes alcanzado.");
                        cliente.Close();
                    }
                }
                catch (Exception ex)
                {
                    form.ActualizarBitacora($"Error al aceptar cliente: {ex.Message}");
                }
            }
        }

        public void ClienteDesconectado(TcpClient cliente)
        {
            if (clientes.Contains(cliente))
            {
                clientes.Remove(cliente);
                form.ActualizarContador(clientes.Count);
                form.ActualizarBitacora("Cliente desconectado.");
            }
        }
    }
}


