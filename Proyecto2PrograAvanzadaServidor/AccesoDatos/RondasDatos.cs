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
    public static class RondasDatos
    {

        public static List<RondasEntidad> ObtenerPorBatalla(int idBatalla) //metodo obtiene rondas por batalla
        {
            List<RondasEntidad> lista = new List<RondasEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();

                string query = @"SELECT r.idRonda,r.idBatalla,r.GanadorRonda FROM Rondas r JOIN Batalla b ON r.idBatalla = b.idBatalla WHERE r.idBatalla = @IdBatalla;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdBatalla", idBatalla);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new RondasEntidad
                            {
                                IdRonda = Convert.ToInt32(reader["IdRonda"]),
                                GanadorRonda = Convert.ToInt32(reader["GanadorRonda"]),

                            });
                        }
                    }
                }
            }

            return lista; //retorna lista rondas y ganador
        }
        public static void RegistrarRonda(RondasEntidad ronda) //metodo registra ronda
        {
            try
            {
                using (SqlConnection conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();
                    string queryRonda = @"
                            INSERT INTO Rondas (IdBatalla, NumeroRonda, IdInventarioAtacante, IdInventarioDefensor, GanadorRonda)
                            VALUES (@IdBatalla, @NumeroRonda, @IdInventarioAtacante, @IdInventarioDefensor, @GanadorRonda);";

                    using (SqlCommand cmdRonda = new SqlCommand(queryRonda, conn))
                    {
                        
                        cmdRonda.Parameters.AddWithValue("@IdBatalla", ronda.IdBatalla);
                        cmdRonda.Parameters.AddWithValue("@NumeroRonda", ronda.NumeroRonda);
                        cmdRonda.Parameters.AddWithValue("@IdInventarioAtacante", ronda.IdInventarioAtacante);
                        cmdRonda.Parameters.AddWithValue("@IdInventarioDefensor", ronda.IdInventarioDefensor);
                        cmdRonda.Parameters.AddWithValue("@GanadorRonda", ronda.GanadorRonda);

                        cmdRonda.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception)
            {
                throw; //relanza la excepcion capturada por el catch
            }
        }

        public static void ActualizarGanador(int idganador,int idbatalla) //metodo registra ronda
        {
            try
            {
                using (SqlConnection conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();
                    string queryRonda = @"update dbo.Batalla set Ganador=@Ganador, EstadoBatalla= 'Finalizada' where IdBatalla = @IdBatalla;";

                    using (SqlCommand cmdRonda = new SqlCommand(queryRonda, conn))
                    {

                        cmdRonda.Parameters.AddWithValue("@IdBatalla",idbatalla);
                        cmdRonda.Parameters.AddWithValue("@Ganador", idganador);
                        

                        cmdRonda.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception)
            {
                throw; //relanza la excepcion capturada por el catch
            }


            
        }
        public static List<RondasEntidad> ObtenerRondasPorBatalla(int idBatalla) //metodo obtiene rondas por batalla
        {
            List<RondasEntidad> lista = new List<RondasEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();

                string query = @"Select IdRonda, IdBatalla, NumeroRonda, IdInventarioAtacante, IdInventarioDefensor, GanadorRonda from dbo.Rondas where IdBatalla = @IdBatalla;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdBatalla", idBatalla);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new RondasEntidad
                            {
                                IdRonda = Convert.ToInt32(reader["IdRonda"]),
                                IdBatalla = Convert.ToInt32(reader["IdBatalla"]),
                                NumeroRonda = Convert.ToInt32(reader["NumeroRonda"]),
                                IdInventarioAtacante = Convert.ToInt32(reader["IdInventarioAtacante"]),
                                IdInventarioDefensor = Convert.ToInt32(reader["IdInventarioDefensor"]),
                                GanadorRonda = Convert.ToInt32(reader["GanadorRonda"]),

                            });
                        }
                    }
                }
            }

            return lista; //retorna lista rondas y ganador
        }
    }
}

