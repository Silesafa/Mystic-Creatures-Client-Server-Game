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
    public static class CriaturaLogica
    {
        public static bool ValidarCosto(int nivel, int costo)     //método valida costo de criatura
        {
            return nivel switch
            {
                1 => costo < 100,
                2 => costo >= 100 && costo < 300,
                3 => costo >= 300 && costo < 600,
                4 => costo >= 600 && costo < 1200,
                5 => costo >= 1200,
                _ => false
            };
        }

            public static string ObtenerNivelCriatura(int nivel) //método obtiene nivel de criatura pasandolo del int ingresado a txt
        {
                switch (nivel)
                {
                    case 1: return "Iniciado";
                    case 2: return "Aprendiz";
                    case 3: return "Estudiante";
                    case 4: return "Avanzado";
                    case 5: return "Maestro";
                    default: return "Desconocido";
                }
            }
        public static CriaturaEntidad BuscarCriaturas(int idCriatura)
        {
            return  CriaturasDatos.BuscarCriaturas(idCriatura);
            
            
        }
          public static void AgregarCriatura(CriaturaEntidad nueva, out string mensaje)
        {
            var resuktado=CriaturasDatos.AgregarCriatura(nueva, out mensaje);

        }

        public static List <CriaturaEntidad> ObtenerCriaturas()
        {
            return CriaturasDatos.ObtenerCriaturas();


        }
        public static List<CriaturaEntidad>ObtenerCriaturasPorJugador(int idJugador)
        {
            return CriaturasDatos.ObtenerCriaturasPorJugador(idJugador);


        }


    }


    }

