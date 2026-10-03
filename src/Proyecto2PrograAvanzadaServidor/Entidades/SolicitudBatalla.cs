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



using System.Net.Sockets;

namespace Entidades
{
    public class SolicitudBatalla
    {
        public int IdJugador { get; set; }
        public int IdBatalla { get; set; }

        public TcpClient Cliente { get; set; } //para que otras entidades que lo necesitan puedan leer o asignar 
        public int IdEquipo{ get; set; }

    }
}
