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
    public static class CriaturasDatos
    {
        public static bool AgregarCriatura(CriaturaEntidad nueva, out string mensaje) //metodo agrega una criatura
        {
            try
            {
                using (SqlConnection conn = new ConexionBD().ObtenerConexion())
                {
                    conn.Open();

                    // Validamos que no exista Id repetido
                    string validar = "SELECT COUNT(*) FROM TiendaCriaturas WHERE IdCriatura = @Id";
                    using (SqlCommand cmdValidar = new SqlCommand(validar, conn))
                    {
                        cmdValidar.Parameters.AddWithValue("@Id", nueva.IdCriatura);
                        int existe = (int)cmdValidar.ExecuteScalar();

                        if (existe > 0)
                        {
                            mensaje = "Ya existe una criatura con ese ID.";
                            return false;
                        }
                    }

                    string query = @"INSERT INTO TiendaCriaturas 
                                    ( Nombre, Tipo, Nivel, Poder, Resistencia, Costo)
                                    VALUES 
                                    (@Nombre, @Tipo, @Nivel, @Poder, @Resistencia, @Costo)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))   //inserta en tabla tiendacriaturas
                    {
                        cmd.Parameters.AddWithValue("@IdCriatura", nueva.IdCriatura);
                        cmd.Parameters.AddWithValue("@Nombre", nueva.Nombre ?? "");
                        cmd.Parameters.AddWithValue("@Tipo", nueva.Tipo ?? "");
                        cmd.Parameters.AddWithValue("@Nivel", nueva.Nivel);
                        cmd.Parameters.AddWithValue("@Poder", nueva.Poder);
                        cmd.Parameters.AddWithValue("@Resistencia", nueva.Resistencia);
                        cmd.Parameters.AddWithValue("@Costo", nueva.Costo);

                        int filas = cmd.ExecuteNonQuery();
                        mensaje = "El registro se ha ingresado correctamente.";
                        return filas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar criatura: " + ex.Message;
                return false;
            }
        }

        public static List<CriaturaEntidad> ObtenerCriaturas()  //metodo obtiene una lista criaturas
        {
            List<CriaturaEntidad> lista = new List<CriaturaEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM TiendaCriaturas ORDER BY IdCriatura";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CriaturaEntidad
                        {
                            IdCriatura = Convert.ToInt32(reader["IdCriatura"]),
                            Nombre = reader["Nombre"].ToString(),
                            Tipo = reader["Tipo"].ToString(),
                            Nivel = Convert.ToInt32(reader["Nivel"].ToString()),
                            Poder = Convert.ToInt32(reader["Poder"]),
                            Resistencia = Convert.ToInt32(reader["Resistencia"]),
                            Costo = Convert.ToInt32(reader["Costo"])
                        });
                    }
                }
            }

            return lista; //devuelve lista
        }

        public static bool ExisteId(int id)  //metodo verifica si exite ID
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TiendaCriaturas WHERE IdCriatura = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static int ObtenerCantidad() //metodo para obtener cantidad de criaturas
        {
            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TiendaCriaturas";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public static List<CriaturaEntidad> ObtenerCriaturasporIdJugador(int idjugador) //metodo para obtener cantidad de criaturas por Idjugador
        {
            List<CriaturaEntidad> lista = new List<CriaturaEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = $"SELECT * FROM TiendaCriaturas ORDER BY IdCriatura";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CriaturaEntidad
                        {
                            IdCriatura = Convert.ToInt32(reader["IdCriatura"]),
                            Nombre = reader["Nombre"].ToString(),
                            Tipo = reader["Tipo"].ToString(),
                            Nivel = Convert.ToInt32(reader["Nivel"].ToString()),           
                            Poder = Convert.ToInt32(reader["Poder"]),
                            Resistencia = Convert.ToInt32(reader["Resistencia"]),
                            Costo = Convert.ToInt32(reader["Costo"])
                        });
                    }
                }
            }

            return lista; //devuelve lista
        }

        public static CriaturaEntidad BuscarCriaturas(int IdCriatura)  //metodo para buscar criaturas
        {
            CriaturaEntidad criatura = new CriaturaEntidad();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = $"Select * From dbo.TiendaCriaturas where IdCriatura = {IdCriatura}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {


                        criatura.IdCriatura = Convert.ToInt32(reader["IdCriatura"]);
                        criatura.Nombre = reader["Nombre"].ToString();
                        criatura.Tipo = reader["Tipo"].ToString();
                        criatura.Nivel = Convert.ToInt32(reader["Nivel"].ToString());
                        criatura.Poder = Convert.ToInt32(reader["Poder"]);
                        criatura.Resistencia = Convert.ToInt32(reader["Resistencia"]);
                        criatura.Costo = Convert.ToInt32(reader["Costo"]);

                    }
                }
            }

            return criatura; //devuelve criatura
        }
        public static List<CriaturaEntidad> ObtenerCriaturasPorJugador(int IdJugador)   //metodo obtiene criaturas que posee el jugador
        {
            List <CriaturaEntidad> criaturas = new List <CriaturaEntidad>();

            using (SqlConnection conn = new ConexionBD().ObtenerConexion())
            {
                conn.Open();
                string query = $"Select tc.IdCriatura,tc.Nombre,tc.Tipo, tc.Nivel,tc.Poder,tc.Resistencia,tc.Costo from dbo.TiendaCriaturas tc inner join dbo.InventarioJugador inv on tc.IdCriatura = inv.IdCriatura inner join dbo.Jugadores jg on jg.IdJugador = inv.IdJugador Where inv.IdJugador = {IdJugador}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var criatura = new CriaturaEntidad();

                        criatura.IdCriatura = Convert.ToInt32(reader["IdCriatura"]);
                        criatura.Nombre = reader["Nombre"].ToString();
                        criatura.Tipo = reader["Tipo"].ToString();
                        criatura.Nivel = Convert.ToInt32(reader["Nivel"].ToString());
                        criatura.Poder = Convert.ToInt32(reader["Poder"]);
                        criatura.Resistencia = Convert.ToInt32(reader["Resistencia"]);
                        criatura.Costo = Convert.ToInt32(reader["Costo"]);

                        criaturas.Add(criatura);

                    }
                }
            }

            return criaturas; //devuelve las criaturas del jugador
        }


    }
}
