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
    public class InventarioDatos
    {
        public bool AgregarInventario(InventarioJugadorEntidad nuevo, out string mensaje)  //metodo agrega criaturas al inventario
        {
            try
            {
                using (SqlConnection conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();

                    string validar = @"SELECT COUNT(*) FROM InventarioJugador 
                                       WHERE IdJugador = @IdJugador AND IdCriatura = @IdCriatura";
                    using (SqlCommand cmdValidar = new SqlCommand(validar, conn))
                    {
                        cmdValidar.Parameters.AddWithValue("@IdJugador", nuevo.IdJugador);
                        cmdValidar.Parameters.AddWithValue("@IdCriatura", nuevo.IdCriatura);
                        int existe = (int)cmdValidar.ExecuteScalar();

                        if (existe > 0)
                        {
                            mensaje = "La criatura ya está en el inventario del jugador.";
                            return false;
                        }
                    }

                    string query = @"INSERT INTO InventarioJugador 
                                     (IdJugador, IdCriatura, Poder, PoderInicial, Resistencia)
                                     VALUES (@IdJugador, @IdCriatura, @Poder, @PoderInicial, @Resistencia)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdJugador", nuevo.IdJugador);
                        cmd.Parameters.AddWithValue("@IdCriatura", nuevo.IdCriatura);
                        cmd.Parameters.AddWithValue("@Poder", nuevo.Poder);
                        cmd.Parameters.AddWithValue("@PoderInicial", nuevo.PoderInicial);
                        cmd.Parameters.AddWithValue("@Resistencia", nuevo.Resistencia);

                        int filas = cmd.ExecuteNonQuery();
                        mensaje = "El registro se ha ingresado correctamente.";
                        return filas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar inventario: " + ex.Message;
                return false;
            }
        }

        public List<InventarioJugadorEntidad> ObtenerInventario()  //metodo que devuelve el Inventario del jugador
        {
            var lista = new List<InventarioJugadorEntidad>();
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM InventarioJugador";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new InventarioJugadorEntidad
                        {
                            IdJugador = reader.GetInt32(0),
                            IdCriatura = reader.GetInt32(1),
                            Poder = reader.GetInt32(2),
                            PoderInicial = reader.GetInt32(3),
                            Resistencia = reader.GetInt32(4)
                        });
                    }
                }
            }
            return lista; //retorna lista del inventario
        }

        public bool ExisteInventario(int idJugador, int idCriatura) //metodo que verifica exitencia de criatura en inventario del jugador
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM InventarioJugador 
                                 WHERE IdJugador = @IdJugador AND IdCriatura = @IdCriatura";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador);
                    cmd.Parameters.AddWithValue("@IdCriatura", idCriatura);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void AumentarPoder(int idJugador, int idCriatura)  //metodo para aumentar poder criatura
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE InventarioJugador 
                                 SET Poder = Poder + 5 
                                 WHERE IdJugador = @IdJugador AND IdCriatura = @IdCriatura";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador);
                    cmd.Parameters.AddWithValue("@IdCriatura", idCriatura);
                    cmd.ExecuteNonQuery();  //ejecuta comandos SQL
                }
            }
        }


        public bool ExisteCriatura(int idJugador, int idCriatura) // Exite ciratura?
        {
            return ExisteInventario(idJugador, idCriatura);
        }

        public void ReiniciarInventario() //metodo para borrar inventario de un jugador
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM InventarioJugador";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();  //ejecuta comandos SQL
                }
            }
        }

        public static bool RegistrarInventarioPorJugador(CompraInventarioEntidad compra) //metodo registra Inventario por jugador
        {
            List<CriaturaEntidad> criaturas = new List<CriaturaEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string validar = @"SELECT COUNT(*) FROM InventarioJugador 
                   WHERE IdJugador = @IdJugador AND IdCriatura = @IdCriatura";
                using (SqlCommand cmdValidar = new SqlCommand(validar, conn))
                {
                    cmdValidar.Parameters.AddWithValue("@IdJugador", compra.Jugador.IdJugador);
                    cmdValidar.Parameters.AddWithValue("@IdCriatura", compra.Criatura.IdCriatura);
                    int existe = (int)cmdValidar.ExecuteScalar();

                    if (existe > 0)
                    {
                        return false; // ya existe no hacer registro
                    }
                }
                string query = $"insert into  dbo.InventarioJugador (IdJugador,IdCriatura,Poder,Resistencia,FechaObtencion) values ({compra.Jugador.IdJugador},{compra.Criatura.IdCriatura},{compra.Criatura.Poder},{compra.Criatura.Resistencia}, GETDATE()) UPDATE DBO.Jugadores set Cristales = Cristales - {compra.Criatura.Costo} where IdJugador = {compra.Jugador.IdJugador}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {


                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

        }
        public static List<CriaturaEntidad> ObtenerPorJugador(int idJugador) //metodo obtiene listas de criaturas por jugador
        {
            List<CriaturaEntidad> lista = new List<CriaturaEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();

                string query = $"SELECT c.IdCriatura,c.Nombre,c.Tipo,c.Nivel,c.Poder,c.Resistencia FROM InventarioJugador i JOIN TiendaCriaturas c ON i.IdCriatura = c.IdCriatura WHERE i.IdJugador = @IdJugador";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CriaturaEntidad
                            {
                                IdCriatura = Convert.ToInt32(reader["IdCriatura"]),
                                Nombre = reader["Nombre"].ToString(),
                                Tipo = reader["Tipo"].ToString(),
                                Nivel = Convert.ToInt32(reader["Nivel"]),
                                Poder = Convert.ToInt32(reader["Poder"]),
                                Resistencia = Convert.ToInt32(reader["Resistencia"])
                            });
                        }
                    }
                }
            }

            return lista; //devuelve lista
        }

    }
   }





