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

namespace AccesoDatos
{
    public class ConexionBD   //genera una conexion a SQL a batallas 
    {
        private string cadena = "Server=localhost\\SQLEXPRESS;Database=BATALLAS;Trusted_Connection=True;";


        public SqlConnection ObtenerConexion() 
        {
            return new SqlConnection(cadena); // devuelve una conexion
        }
    }
}
