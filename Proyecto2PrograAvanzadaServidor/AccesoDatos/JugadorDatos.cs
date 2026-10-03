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

using Entidades;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class JugadorDatos
    {
        public bool AgregarJugador(JugadorEntidad nuevo, out string mensaje)  //metodo que agrega jugador
        {
            try
            {
                using (SqlConnection conn = new ConexionBD().ObtenerConexion()) //abre conexion con BD
                {
                    conn.Open(); //activa conexion y permite usar select, insert, update,ect

                    // Validamos si el usuario existe
                    string validar = "SELECT COUNT(*) FROM Jugadores WHERE Usuario = @Usuario";
                    using (SqlCommand cmdValidar = new SqlCommand(validar, conn)) //valida con el servidor
                    {
                        cmdValidar.Parameters.AddWithValue("@Usuario", nuevo.Usuario ?? ""); //asigna un nuevo usuario a validar
                        int existe = (int)cmdValidar.ExecuteScalar(); //la consulta devuelve un solo valor (usuario)
                                                                                //?? evita que buevo usuario sea nulo
                        if (existe > 0)
                        {
                            mensaje = "Ya existe un jugador con ese Usuario.";
                            return false;
                        }
                    }

                    // Insertamos un nuevo jugador
                    string query = @"INSERT INTO Jugadores 
                            (Nombre, Usuario, Password, FechaNacimiento, Nivel, Cristales)
                            VALUES 
                            (@Nombre, @Usuario, @Password, @FechaNacimiento, @Nivel, @Cristales)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nuevo.NombreJugador ?? "");
                        cmd.Parameters.AddWithValue("@Usuario", nuevo.Usuario ?? "");
                        cmd.Parameters.AddWithValue("@Password", nuevo.Password ?? "");
                        cmd.Parameters.AddWithValue("@FechaNacimiento", nuevo.FechaNacimiento); 
                        cmd.Parameters.AddWithValue("@Nivel", nuevo.Nivel);
                        cmd.Parameters.AddWithValue("@Cristales", nuevo.Cristales);

                        int filas = cmd.ExecuteNonQuery(); //instruccion Ado.Net ejecuta comandos SQL insert,Select, update
                        mensaje = "El registro se ha ingresado correctamente.";
                        return filas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar jugador: " + ex.Message;
                return false;
            }
        }


        public List<JugadorEntidad> ObtenerJugadores()   //metodo obtiene una lista de Jugadores
        {
            List<JugadorEntidad> lista = new List<JugadorEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion()) //abre conexion con BD
            {
                conn.Open();//activa conexion y permite usar select, insert, update,ect

                string query = "SELECT IdJugador, Nombre, FechaNacimiento, Nivel, Cristales, Usuario, Password FROM Jugadores";

                using (SqlCommand cmd = new SqlCommand(query, conn)) //ejecuta consultas SQL 
                using (SqlDataReader reader = cmd.ExecuteReader())   // devuelve resultados para leerlos por fila
                {
                    while (reader.Read())
                    {
                        lista.Add(new JugadorEntidad
                        {
                            IdJugador = Convert.ToInt32(reader["IdJugador"]),
                            NombreJugador = reader["Nombre"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]), 
                            Nivel = Convert.ToInt32(reader["Nivel"]),
                            Cristales = Convert.ToInt32(reader["Cristales"]),
                            Usuario = reader["Usuario"].ToString(),
                            Password = reader["Password"].ToString()
                        });
                    }
                }
            }

            return lista;
        }


        public bool ExisteJugador(int idJugador) //metodo Existe el jugador
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Jugadores WHERE IdJugador = @IdJugador";
                using (SqlCommand cmd = new SqlCommand(query, conn)) //comando SQL vinculado a conexion
                {
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador); //devuelve IdJugador
                    int count = (int)cmd.ExecuteScalar(); //ejecuta consulta y obtiene un entero como resultado
                    return count > 0;
                }
            }
        }

        public bool AgregarCristales(int idJugador, int cantidad) //metodo agregar cristales
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE Jugadores SET Cristales = Cristales + @Cantidad WHERE IdJugador = @IdJugador";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool IncrementarGanadas(int idJugador) //metodo incrementar batallas Ganadas
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE Jugadores SET BatallasGanadas = BatallasGanadas + 1 WHERE IdJugador = @IdJugador";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public static JugadorEntidad ObtenerJugadorPorID(int IdJugador) //metodo Obtener jugador
        {
            JugadorEntidad Jugador = new JugadorEntidad();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = $"SELECT IdJugador, Nombre, FechaNacimiento, Nivel, Cristales, Usuario, Password FROM Jugadores where IdJugador = {IdJugador} ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Jugador.IdJugador = Convert.ToInt32(reader["IdJugador"]);
                        Jugador.NombreJugador = reader["Nombre"].ToString();
                        Jugador.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]); 
                        Jugador.Nivel = Convert.ToInt32(reader["Nivel"]);
                        Jugador.Cristales = Convert.ToInt32(reader["Cristales"]);
                        Jugador.Usuario = reader["Usuario"].ToString();
                        Jugador.Password = reader["Password"].ToString();
                    }    
                }
            }

            return Jugador;
        }


       public static List<JugadorEntidad> ObtenerTop10Ganadores() //metodo obtiene top10 ganadores
            {
                List<JugadorEntidad> lista = new List<JugadorEntidad>();

                using (SqlConnection conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();
                    string query = $"SELECT TOP 10 j.idJugador,j.Nombre AS NombreJugador, COUNT(*) AS BatallasGanadas FROM Batalla b JOIN Jugadores j ON b.Ganador = j.idJugador GROUP BY j.idJugador, j.Nombre ORDER BY BatallasGanadas DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new JugadorEntidad
                            {
                                IdJugador = Convert.ToInt32(reader["IdJugador"]),
                                NombreJugador = reader["Nombre"].ToString(),
                                BatallasGanadas = Convert.ToInt32(reader["BatallasGanadas"])
                            });
                        }

                    }
                    
                }

                return lista;
            }
        public static List<JugadorEntidad> ObtenerTodos() //metodo crea una lista de obj Jugador Entidad y devuelve la lista
        {
            var lista = new List<JugadorEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT IdJugador, Nombre FROM Jugadores";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new JugadorEntidad
                        {
                            IdJugador = reader.GetInt32(0),
                            NombreJugador = reader.GetString(1)
                        });
                    }
                }
            }

            return lista;
        }
        public List<JugadorEntidad> ObtenerTopJugadores()   //metodo obtiene una lista de Jugadores
        {
            List<JugadorEntidad> lista = new List<JugadorEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion()) //abre conexion con BD
            {
                conn.Open();//activa conexion y permite usar select, insert, update,ect

                string query = "Select Top(10) bt.Ganador,count(bt.Ganador) as Victorias, jg.Nombre from dbo.Batalla bt inner join dbo.Jugadores jg on bt.Ganador= jg.IdJugador group by Ganador,jg.Nombre order by Victorias desc";

                using (SqlCommand cmd = new SqlCommand(query, conn)) //ejecuta consultas SQL 
                using (SqlDataReader reader = cmd.ExecuteReader())   // devuelve resultados para leerlos por fila
                {
                    while (reader.Read())
                    {
                        lista.Add(new JugadorEntidad
                        {
                            IdJugador = Convert.ToInt32(reader["Ganador"]),
                            NombreJugador = reader["Nombre"].ToString(),                        
                            Victorias = Convert.ToInt32(reader["Victorias"]),
                            
                        });
                    }
                }
            }

            return lista;
        }
        public List<BatallaEntidad> ObtenerBatallasPorJugador(int IdJugador)   //metodo obtiene una lista de Jugadores
        {
            List<BatallaEntidad> lista = new List<BatallaEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion()) //abre conexion con BD
            {
                conn.Open();//activa conexion y permite usar select, insert, update,ect

                string query = $"select IdBatalla, IdEquipo1, IdEquipo2, Fecha, Ganador, EstadoBatalla from Batalla where Ganador = {IdJugador}";
                using (SqlCommand cmd = new SqlCommand(query, conn)) //ejecuta consultas SQL 
                using (SqlDataReader reader = cmd.ExecuteReader())   // devuelve resultados para leerlos por fila
                {
                    while (reader.Read())
                    {
                        lista.Add(new BatallaEntidad
                        {
                            IdBatalla = Convert.ToInt32(reader["IdBatalla"]),
                            IdEquipo1 = Convert.ToInt32(reader["IdEquipo1"]),
                            IdEquipo2 = Convert.ToInt32(reader["IdEquipo2"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Ganador = Convert.ToInt32(reader["Ganador"]),
                            Estado = reader["EstadoBatalla"].ToString(),
                            

                        });
                    }
                }
            }

            return lista;
        }
       
    }

}

