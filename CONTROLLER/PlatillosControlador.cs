using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace CONTROLLER
{
    public class PlatillosControlador
    {
        /// <summary>
        /// Busca platillos en la base de datos atraves de los criterios
        /// </summary>
        /// <param name="criterios">string Criterios para buscar</param>
        /// <param name="estado">bool Estado del platillo</param>
        /// <returns>Retorna la consulta</returns>
        public static List<Platillo> BuscarPlatilloCriterios(string criterios, bool estado)
        {
            try
            {
                return PlatillosModel.BuscarPlatilloCriterios(criterios, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Cambiar el estado del platillo activo-innactivo
        /// </summary>
        /// <param name="idPlatillo">Identificador del platillo</param>
        public static void CambiarEstadoPlatillo(int idPlatillo)
        {
            try
            {
                if (idPlatillo > 0)
                {
                    PlatillosModel.CambiarEstadoPlatillo(idPlatillo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }
    }
}
