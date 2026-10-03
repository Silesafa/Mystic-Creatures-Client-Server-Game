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

namespace Entidades
{
    public class CriaturaEntidad  // clase con métodos get/set
    {
        public int IdCriatura { get; set; }
        public string Nombre { get; set; } = string.Empty; // No aseguramos que nunca este null 
        public string Tipo { get; set; } = string.Empty;//  Agua, Tierra, Aire, Fuego
        public int Nivel { get; set; }   // 1 a 5
        public int Poder { get; set; }
        public int Resistencia { get; set; }
        public int Costo { get; set; }

        public int IdInventario { get; set; }

        public int IdJugador { get; set; }


    }
}

