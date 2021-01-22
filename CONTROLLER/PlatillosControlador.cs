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
        public static List<Platillo> BuscarPlatilloCriterios(string criterios, bool estado)
        {
            try
            {
                return PlatillosModel.BuscarPlatilloCriterios(criterios, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }
        }

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
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }
        }
    }
}
