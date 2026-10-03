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


namespace Logica
{
    public static class JugadorLogica
    {
        public static bool ValidarEdad(DateTime fechaNacimiento)  // validar edad
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (fechaNacimiento > DateTime.Now.AddYears(-edad)) edad--;
            return edad >= 10;
        }

        public static int DeterminarNivel(int batallasGanadas) //  batallas ganadas y determina nivel
        {
            if (batallasGanadas >= 20) return 4;
            if (batallasGanadas >= 10) return 3;
            if (batallasGanadas >= 5) return 2;
            return 1;
        }

        public static string ObtenerDescripcionNivel(int nivel)  //pasa nivel de int a string
        {
            switch (nivel)
            {
                case 1: return "Novato";
                case 2: return "Estudiante";
                case 3: return "Maestro";
                case 4: return "Supremo";
                default: return "Desconocido";
            }
        }

        public static JugadorEntidad ObtenerJugadorPorID(int IdJugador) {
        
        
        return JugadorDatos.ObtenerJugadorPorID(IdJugador);    
        
        }

    }

}
