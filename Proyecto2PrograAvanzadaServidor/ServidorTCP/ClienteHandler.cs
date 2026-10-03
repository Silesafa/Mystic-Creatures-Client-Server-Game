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

using AccesoDatos;
using Entidades;
using Logica;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace ServidorTCP
{
    public class ClienteHandler
    {
        private TcpClient cliente;   //cliente que se conecta
        private FormServidorTCP form; //referencia al fromServidor
        private ServidorTCP servidor; //permite acceso a metodos compartidos

        private static SolicitudBatalla SolicitudJugador1;   //alacenan solicitudes de batalla
        private static SolicitudBatalla SolicitudJugador2;

        public ClienteHandler(TcpClient cliente, FormServidorTCP form, ServidorTCP servidor)
        {
            this.cliente = cliente;
            this.form = form;
            this.servidor = servidor;
        }

        public void Procesar() //procesa conexion entre cliente-server
        {
            try
            {
                NetworkStream stream = cliente.GetStream();
                byte[] buffer = new byte[8192]; //bytes del buffer se cambio de 1024 a 8192 para poder enviar mas info de ser necesario
                int bytesLeidos;

                while ((bytesLeidos = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                    form.ActualizarBitacora($"Mensaje recibido: {mensaje}");   //recibe msj y actualiza bitacora
                    string respuesta = "";

                    if (mensaje.StartsWith("LOGIN|"))
                    {
                        string[] partes = mensaje.Split('|'); //divide el string en partes  (pipe)
                        if (partes.Length == 3)
                        {
                            string usuario = partes[1];
                            string password = partes[2];

                            var jugadores = new JugadorDatos().ObtenerJugadores();
                            var jugador = jugadores.FirstOrDefault(j =>
                                j.Usuario.Equals(usuario, StringComparison.OrdinalIgnoreCase) &&
                                j.Password == password);

                            if (jugador != null)
                            {
                                respuesta = $"OK|{jugador.NombreJugador}|{jugador.IdJugador}";
                                form.ActualizarBitacora($"Jugador validado: conectado {jugador.NombreJugador}");
                            }
                            else
                            {
                                respuesta = "ERROR|Credenciales inválidas";
                                form.ActualizarBitacora("Intento de login fallido");


                                servidor.ClienteDesconectado(cliente);
                                cliente.Close();
                                return;
                            }
                        }
                        else
                        {
                            respuesta = "ERROR|Formato incorrecto";
                            form.ActualizarBitacora("Login mal formado");
                        }
                    }
                    else if (mensaje.StartsWith("LISTA_CRIATURAS|"))
                    {
                        string[] partes = mensaje.Split('|');
                        string IdJugador = partes[1];
                        RespuestaInventarioEntidad Respuesta = new RespuestaInventarioEntidad();
                        Respuesta.ListaCriaturas = CriaturaLogica.ObtenerCriaturas();
                        Respuesta.ListaCriaturasPorJugador = CriaturaLogica.ObtenerCriaturasPorJugador(Convert.ToInt32(IdJugador));
                        Respuesta.Jugador = JugadorLogica.ObtenerJugadorPorID(Convert.ToInt32(IdJugador));
                        string json = JsonConvert.SerializeObject(Respuesta);
                        respuesta = "LISTA|" + json;

                    }
                    else if (mensaje.StartsWith("REGISTRAR_INVENTARIO_JUGAGOR|"))
                    {
                        string[] partes = mensaje.Split('|');
                        string json = partes[1];
                        var compra = JsonConvert.DeserializeObject<CompraInventarioEntidad>(json);
                        var respuestaRegistro = LogicaInventario.RegistrarInventarioPorJugador(compra);
                        string jsonrespuesta = JsonConvert.SerializeObject(respuestaRegistro);
                        respuesta = "LISTA|" + jsonrespuesta;

                    }
                    else if (mensaje.StartsWith("INICIAR_BATALLA|"))
                    {
                        string[] partes = mensaje.Split('|');
                        int idJugador = Convert.ToInt32(partes[1]);
                        int idEquipo = Convert.ToInt32(partes[2]);
                        

                        BatallaEntidad batalla = new BatallaEntidad();

                        if (SolicitudJugador1 ==null)
                        {
                            SolicitudJugador1 = new SolicitudBatalla();
                            SolicitudJugador1.IdEquipo = idEquipo;
                            SolicitudJugador1.IdJugador = idJugador;
                            SolicitudJugador1.Cliente = cliente;
                            
                            respuesta = "ESPERA";
                            form.ActualizarBitacora($"Jugador {idJugador} en espera de batalla.");
                        }
                        else
                        {
                            SolicitudJugador2 = new SolicitudBatalla();
                            SolicitudJugador2.IdEquipo = idEquipo;
                            SolicitudJugador2.IdJugador = idJugador;
                            SolicitudJugador2.Cliente = cliente;

                            batalla.IdEquipo1 = SolicitudJugador1.IdEquipo;
                            batalla.IdEquipo2 = SolicitudJugador2.IdEquipo;
                            batalla.Ganador = SolicitudJugador1.IdJugador;
                            batalla.Estado = "pendiente";
                            int idBatalla = LogicaBatalla.RegistrarBatalla(batalla);
                          
                            EnviarMensaje(SolicitudJugador1.Cliente, $"BATALLA_INICIADA|{idBatalla}");
                            EnviarMensaje(SolicitudJugador2.Cliente, $"BATALLA_INICIADA|{idBatalla}");

                            var rondas = LogicaBatalla.EjecutarBatalla(SolicitudJugador1, SolicitudJugador2, idBatalla);
                            string jsonrespuesta = JsonConvert.SerializeObject(rondas);
                
                            EnviarMensajeRonda(SolicitudJugador1.Cliente, $"RONDA_FINALIZADA|{jsonrespuesta}");
                            EnviarMensajeRonda(SolicitudJugador2.Cliente, $"RONDA_FINALIZADA|{jsonrespuesta}");

                            LogicaBatalla.DeterminarGanador(rondas, SolicitudJugador1.IdJugador, SolicitudJugador2.IdJugador, idBatalla);
                            //var settings = new JsonSerializerSettings
                            //{
                            //    ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver()          //agragdo2
                            //};

                            //string jsonrespuesta = JsonConvert.SerializeObject(rondas, settings);
                            //form.ActualizarBitacora($"JSON de rondas enviado: {jsonrespuesta}");


                            //string jsonrespuesta = JsonConvert.SerializeObject(rondas);



                            // form.ActualizarBitacora($"Batalla {idBatalla} iniciada entre {jugador1.IdJugador} y {jugador2.IdJugador}");
                            continue; // para evitar enviar respuesta duplicada
                        }
                    }
                    else if (mensaje.StartsWith("CONSULTAR_HISTORIAL|"))
                    {
                        string[] partes = mensaje.Split('|');
                        string IdJugador = partes[1];
                        string IdBatalla = partes[2];
                        HistorialEntidad Respuesta = new HistorialEntidad();
                        Respuesta = LogicaBatalla.ConsultarHistorial(Convert.ToInt32(IdJugador), Convert.ToInt32(IdBatalla));
                        string json = JsonConvert.SerializeObject(Respuesta);
                        respuesta =  json;

                    }
                    
                    // Enviar respuesta si no se desconectó
                    byte[] respuestaBytes = Encoding.UTF8.GetBytes(respuesta);
                    stream.Write(respuestaBytes, 0, respuestaBytes.Length);
                }

            }



            catch (Exception ex)
            {
                form.ActualizarBitacora($"Error con cliente: {ex.Message}");
            }
            finally
            {
                servidor.ClienteDesconectado(cliente);
                cliente.Close();
            }
        }
        private void EnviarMensaje(TcpClient destino, string mensaje)  //envia msj 
        {
            byte[] datos = Encoding.UTF8.GetBytes(mensaje);
            destino.GetStream().Write(datos, 0, datos.Length);   
        }
        private void EnviarMensajeRonda(TcpClient destino, string mensaje)
        {
            byte[] datos = Encoding.UTF8.GetBytes(mensaje.Trim());
            destino.GetStream().Write(datos, 0, datos.Length);         //modificado3
        }

    }
}