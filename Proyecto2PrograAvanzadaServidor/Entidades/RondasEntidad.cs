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

namespace Entidades   // Clase rondas
{
    
        public class RondasEntidad
        {
            public int IdRonda { get; set; } // # 1, 2 o 3
            public int IdBatalla { get; set; }
            public int IdJugador1 { get; set; }
            public int IdCriatura1 { get; set; }
            public int IdJugador2 { get; set; }
            public int IdCriatura2 { get; set; }
            public int GanadorRonda { get; set; }
            public int IdGanador { get; set; } // ID del jugador que ganó la ronda
            public int IdCriaturaGanadora { get; set; } // ID de la criatura que ganó
            public int IdInventarioAtacante { get; set; }
            public int IdInventarioDefensor { get; set; }
            public int NumeroRonda { get; set; }

    }
}


