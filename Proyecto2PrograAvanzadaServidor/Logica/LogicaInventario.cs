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
    public class LogicaInventario
    {
        private InventarioJugadorEntidad[] inventario = new InventarioJugadorEntidad[30]; //Arreglo guarda criaturas compradas

        private int contador = 0;

        public string AgregarCriatura(JugadorEntidad jugador, CriaturaEntidad criatura) // método agregar ciratura
        {
            if (jugador.Cristales < criatura.Costo)
                return "No posee la cantidad de cristales suficientes para obtener la criatura";

            for (int i = 0; i < contador; i++)
            {
                if (inventario[i].IdJugador == jugador.IdJugador &&
                    inventario[i].IdCriatura == criatura.IdCriatura)
                    return "El jugador ya posee esta criatura";
            }

            if (contador >= inventario.Length)
                return "Inventario lleno";

            jugador.Cristales -= criatura.Costo;

            InventarioJugadorEntidad nueva = new InventarioJugadorEntidad  //crea y guarda criatura en invenatario
            {
                IdJugador = jugador.IdJugador,
                IdCriatura = criatura.IdCriatura,
                Poder = criatura.Poder,
                Resistencia = criatura.Resistencia
            };

            inventario[contador++] = nueva;

            return "El registro se ha ingresado correctamente.";
        }

        public InventarioJugadorEntidad[] ObtenerInventario()    //método obtener Inventario
        {
            InventarioJugadorEntidad[] resultado = new InventarioJugadorEntidad[contador];
            for (int i = 0; i < contador; i++)
            {
                resultado[i] = inventario[i];
            }
            return resultado;
        }

        public static RespuestaCompraEntidad RegistrarInventarioPorJugador(CompraInventarioEntidad compra) {

            var respuesta = new RespuestaCompraEntidad();
            var jugador = JugadorLogica.ObtenerJugadorPorID(compra.Jugador.IdJugador);
            if (jugador == null) {

                respuesta.resultado = false;
                respuesta.mensaje = "Jugador no encontrado";
                return respuesta;
            
            }
            if (jugador.Cristales < compra.Criatura.Costo)
            {

                respuesta.resultado = false;
                respuesta.mensaje = "No posee la cantidad de cristales suficientes para obtener la criatura.";
                return respuesta;

            }
            var resultado=InventarioDatos.RegistrarInventarioPorJugador(compra);
            if (resultado == true) {

                respuesta.resultado = true;
                respuesta.mensaje = "Compra Exitosa";
                return respuesta;
            }
            else
            {
                respuesta.resultado = false;
                respuesta.mensaje = "No se pudo realizar compra ";
                return respuesta;

            }
       
        }
    }
 
}


        
    




