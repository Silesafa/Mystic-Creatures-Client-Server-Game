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
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
    public class EquipoDatos
    {
    

        public List<CriaturaEntidad> ObtenerEquiposporJugador(SolicitudBatalla solicitudBatalla) //metodo para obtener equipos por jugador
        {
            var lista = new List<CriaturaEntidad>();
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = $@"Select td.IdCriatura,eq.IdJugador, td.Poder, td.Resistencia, td.Nivel, td.Nombre from dbo.Equipo eq
                                inner join TiendaCriaturas td
                                on eq.IdInventarioCriatura1 = td.IdCriatura or
                                eq.IdInventarioCriatura2 = td.IdCriatura or
                                eq.IdInventarioCriatura3 = td.IdCriatura 
                                where eq.IdJugador= {solicitudBatalla.IdJugador} and eq.IdEquipo ={solicitudBatalla.IdEquipo}";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CriaturaEntidad equipo = new CriaturaEntidad();
                        equipo.IdCriatura = reader.GetInt32(0);
                        equipo.IdJugador = reader.GetInt32(1);
                        equipo.Poder = reader.GetInt32(2);
                        equipo.Resistencia = reader.GetInt32(3);
                        equipo.Nivel = reader.GetInt32(4);
                        equipo.Nombre = reader.GetString(5);

                        lista.Add(equipo);
                    }
                }
            }
            return lista; //devuelve lista
        }

        public bool ExisteEquipo(int idJugador, int idEquipo) //mrtodo que veirifica si existe equipo
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Equipo WHERE IdEquipo = @IdEquipo AND IdJugador = @IdJugador";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdEquipo", idEquipo);
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
              }
            }
            public  List<CriaturaEntidad> ObtenerCriaturasDeEquipoArreglo(int idJugador, int idEquipo) //metodo obtiene una criatura de un arreglo
        {
            var criaturas = new List<CriaturaEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT IdInventarioCriatura1, IdInventarioCriatura2, IdInventarioCriatura3 
                 FROM Equipo 
                 WHERE IdEquipo = @IdEquipo AND IdJugador = @IdJugador";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdEquipo", idEquipo);       //con las criaturas se forma un equipo
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int[] ids = {
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2)
                    };

                            foreach (int idCriatura in ids)    //busca criatura en inventario
                            {
                                CriaturaEntidad criatura = BuscarCriaturaEnInventario(idJugador, idCriatura);
                                if (criatura != null)
                                {
                                    criaturas.Add(criatura); // la agrega al equipo
                                }
                            }
                        }
                    }
                }
            }

            return criaturas; //devuelve las criaturas 
        }

        private static CriaturaEntidad BuscarCriaturaEnInventario(int idJugador, int idCriatura)  //metod busca criatura en Inventario
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT tc.Nombre, ij.Poder, ij.Resistencia
            FROM InventarioJugador ij
            JOIN TiendaCriaturas tc ON ij.IdCriatura = tc.IdCriatura
            WHERE ij.IdJugador = @IdJugador AND ij.IdCriatura = @IdCriatura";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador);
                    cmd.Parameters.AddWithValue("@IdCriatura", idCriatura);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CriaturaEntidad
                            {
                                IdCriatura = idCriatura,
                                Nombre = reader.GetString(0),
                                Poder = reader.GetInt32(1),
                                Resistencia = reader.GetInt32(2)
                            };
                        }
                    }
                }
            }

            return null; //retorna valor nulo
        }
        public static List<EquipoEntidad> ObtenerEquiposPorJugador(int idJugador) //metodo obtener equipos del jugador
        {

            var lista = new List<EquipoEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT IdEquipo, IdJugador, NombreEquipo, IdInventarioCriatura1, IdInventarioCriatura2, IdInventarioCriatura3 FROM Equipo WHERE IdJugador = @IdJugador";



                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdJugador", idJugador);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EquipoEntidad
                            {
                                IdEquipo = reader.GetInt32(0),
                                IdJugador = reader.GetInt32(1),
                                NombreEquipo = reader.GetString(2),
                                IdCriatura1 = reader.GetInt32(3),
                                IdCriatura2 = reader.GetInt32(4),
                                IdCriatura3 = reader.GetInt32(5)


                            });
                        }
                    }
                }
            }

            return lista; //devuelve una lista de equipos
        }
 
    
       
            public static bool RegistrarEquipo(EquipoEntidad equipo, out string mensaje)  //metodo para registrar un equipo
            {
                try
                {
                    using (SqlConnection conn = new ConexionBD().ObtenerConexion())
                    {
                        conn.Open();
                    string query = @"INSERT INTO Equipo (IdJugador, NombreEquipo, FechaCreacion, IdInventarioCriatura1, IdInventarioCriatura2, IdInventarioCriatura3, Activo) VALUES (@IdJugador, @NombreEquipo, @FechaCreacion, @IdInventarioCriatura1, @IdInventarioCriatura2, @IdInventarioCriatura3, @Activo); SELECT SCOPE_IDENTITY(); ";


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                        cmd.Parameters.AddWithValue("@IdJugador", equipo.IdJugador); 
                        cmd.Parameters.AddWithValue("@NombreEquipo", equipo.NombreEquipo);
                        cmd.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);
                        cmd.Parameters.AddWithValue("@IdInventarioCriatura1", equipo.IdCriatura1);
                        cmd.Parameters.AddWithValue("@IdInventarioCriatura2", equipo.IdCriatura2);
                        cmd.Parameters.AddWithValue("@IdInventarioCriatura3", equipo.IdCriatura3);
                        cmd.Parameters.AddWithValue("@Activo", true);
                        int nuevoId = Convert.ToInt32(cmd.ExecuteScalar());

                        mensaje = $"Equipo registrado correctamente: {nuevoId}";
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    mensaje = "Error al registrar el equipo: " + ex.Message;
                    return false;
                }
            }
        }
    }








