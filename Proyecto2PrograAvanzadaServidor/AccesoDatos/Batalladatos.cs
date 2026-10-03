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

namespace AccesoDatos;

public static class BatallaDatos
{

    public static List<BatallaEntidad> ObtenerBatallas() //metodo obtener batallas abre conexion SQL 
    {
        var lista = new List<BatallaEntidad>();
        using (SqlConnection conn = new ConexionBD().ObtenerConexion())
        {
            conn.Open();
            string query = "SELECT * FROM Batallas";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())  //recorre resultados SQLDatareader 
            {
                while (reader.Read())
                {
                    lista.Add(new BatallaEntidad
                    {
                        IdBatalla = reader.GetInt32(0),
                        IdJugador1 = reader.GetInt32(1),
                        IdEquipo1 = reader.GetInt32(2),
                        IdJugador2 = reader.GetInt32(3),
                        IdEquipo2 = reader.GetInt32(4),
                        Ganador = reader.GetInt32(5)
                    });
                }
            }
        }
        return lista;//y devuelve lista
    }


    public static List<BatallaEntidad> ObtenerBatallaPorJugador(int idJugador) //metodo obtiene batallas por jugador
    {
        List<BatallaEntidad> lista = new List<BatallaEntidad>();

        using (SqlConnection conn = new ConexionBD().ObtenerConexion())
        {
            conn.Open();
            string query = @"
            SELECT b.IdBatalla, b.Fecha, b.IdEquipo1, b.IdEquipo2, b.EstadoBatalla
            FROM Batalla b
            JOIN Equipo e1 ON b.IdEquipo1 = e1.IdEquipo
            JOIN Equipo e2 ON b.IdEquipo2 = e2.IdEquipo
            WHERE e1.IdJugador = @IdJugador OR e2.IdJugador = @IdJugador";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IdJugador", idJugador);

                using (SqlDataReader reader = cmd.ExecuteReader()) //recorre resultados SQLDatareader 
                {
                    while (reader.Read())
                    {
                        lista.Add(new BatallaEntidad
                        {
                            IdBatalla = Convert.ToInt32(reader["IdBatalla"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            IdEquipo1 = Convert.ToInt32(reader["IdEquipo1"]),
                            IdEquipo2 = Convert.ToInt32(reader["IdEquipo2"]),
                            //EstadoBatalla = reader["EstadoBatalla"].ToString()
                        });
                    }
                }
            }
        }

        return lista; //y devuelve lista

    }
    public static ResumenBatallaEntidad ObtenerResumenBatalla(int idBatalla) //metodo obtiene resumen batalla
    {
        // Simulación de datos, reemplazá con consulta real
        return new ResumenBatallaEntidad
        {
            IdGanador = 1,
            Cristales = 50,
            Mejoras = "Poder +10"
        };
    }

    public static int RegistrarBatalla(BatallaEntidad Batalla)  //metodo registra una batalla y obtiene un ID automatico
    {
        try
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();

                string query = @"
                INSERT INTO dbo.Batalla (IdEquipo1, IdEquipo2, Fecha, Ganador, EstadoBatalla)
                VALUES (@IdEquipo1, @IdEquipo2, GETDATE(), @Ganador, @EstadoBatalla);
                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdEquipo1", Batalla.IdEquipo1);
                    cmd.Parameters.AddWithValue("@IdEquipo2", Batalla.IdEquipo2);
                    cmd.Parameters.AddWithValue("@Ganador", Batalla.Ganador);
                    cmd.Parameters.AddWithValue("@EstadoBatalla", Batalla.Estado);

                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int idInsertado))
                    {
                        return idInsertado;
                    }
                    else
                    {
                        return -1; //si hay error devuel un -1
                    }
                }
            }
        }
        catch (Exception)
        {
            return -1; //si hay error devuel un -1
        }
    }
}

