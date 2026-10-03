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
    public static class LogicaBatalla
    {
        public static List<RondasEntidad> EjecutarBatalla(SolicitudBatalla jugador1, SolicitudBatalla jugador2, int idBatalla) //ejecuta la batalla
        {
            EquipoDatos datos = new EquipoDatos();
            var criaturas1 = datos.ObtenerEquiposporJugador(jugador1);
            var criaturas2 = datos.ObtenerEquiposporJugador(jugador2);
            List<RondasEntidad> rondas=new List<RondasEntidad>();   
          

            Random rnd = new Random();

            criaturas1 = criaturas1.OrderBy(x => rnd.Next()).ToList();
            criaturas2 = criaturas2.OrderBy(x => rnd.Next()).ToList();


            int victorias1 = 0;
            int victorias2 = 0;

            for (int ronda = 0; ronda < 3; ronda++)
            {
                var criatura1 = criaturas1[ronda];
                var criatura2 = criaturas2[ronda];
                var atacante = 0;
                var defensor = 0;

                int jugadorganador;

                // Elegir aleatoriamente quién ataca
                int jugador1Ataca = rnd.Next(2);

                if (jugador1Ataca ==0 )
                {            
                     jugadorganador = DeterminarGanador(criatura1, criatura2);
                    atacante = criatura1.IdCriatura;
                    defensor = criatura2.IdCriatura;
                }
                else
                {
                    jugadorganador = DeterminarGanador(criatura2, criatura1);
                    atacante = criatura2.IdCriatura;
                    defensor = criatura1.IdCriatura;
                }
                RondasEntidad rondaEntidad = new RondasEntidad
                {
                    
                    IdBatalla = idBatalla,
                    IdInventarioAtacante = atacante,
                    IdInventarioDefensor = defensor,
                    GanadorRonda = jugadorganador,
                    NumeroRonda= ronda + 1,

                };
                rondas.Add(rondaEntidad);
                RondasDatos.RegistrarRonda(rondaEntidad);
            }
            return rondas;
        }

        public static int DeterminarGanador(CriaturaEntidad atacante, CriaturaEntidad defensor) //se determina ganador batalla
        {
            // Simulación básica: gana el que tenga más poder
            if (atacante.Poder > defensor.Resistencia)
                return atacante.IdJugador;
            else
                return defensor.IdJugador;
        }

        public static int RegistrarBatalla(BatallaEntidad Batalla)
        {
            return  BatallaDatos.RegistrarBatalla(Batalla);
          
        }
        public static void DeterminarGanador(List<RondasEntidad> rondas, int idJugador1, int idJugador2,int idBatalla) //metodo para determinar el ganador de rondas
        {
            int victoriasJugador1 = 0;
            int victoriasJugador2 = 0;
            int ganador = 0;

            foreach (var ronda in rondas)
            {
                if (ronda.IdGanador == idJugador1)
                    victoriasJugador1++;
                else if (ronda.IdGanador == idJugador2)
                    victoriasJugador2++;
            }

            if (victoriasJugador1 > victoriasJugador2) {
                ganador = idJugador1;
            }
            else{
                ganador = idJugador2;
            }
            RondasDatos.ActualizarGanador(ganador, idBatalla);
        }
        public static HistorialEntidad ConsultarHistorial( int idJugador, int idBatalla) //metodo historail para llenar los dgv de conultas
        {
            HistorialEntidad historial=new HistorialEntidad();
            JugadorDatos jugadordatos = new JugadorDatos();
            historial.TopJugadores = jugadordatos.ObtenerTopJugadores();
            historial.BatallasPorJugador = jugadordatos.ObtenerBatallasPorJugador(idJugador);
            historial.RondasPorBatalla = RondasDatos.ObtenerRondasPorBatalla(idBatalla);
            historial.ConsultarInventarioJugador = CriaturasDatos.ObtenerCriaturasporIdJugador(idJugador);
            return historial;
        }
    }
}
