using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace CONTROLLER
{
    public class DietaInfoControlador
    {
        /// <summary>
        /// Metodo para insertar la informacion de la dieta en la base de datos
        /// </summary>
        /// <param name="newDietaInfo">DietaInfo Informacion de la dieta a insertar</param>
        public static void InsertarDietaInfo(DietaInfo newDietaInfo)
        {
            try
            {
                DietaInfoModel.InsertarDietaInfo(newDietaInfo);   
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Actualiza la informacion de la dieta en la base de datos
        /// </summary>
        /// <param name="dietaInfoModificado">DietaInfo Informacion actualizada de la dieta</param>
        public static void ModificarDietaInfo(DietaInfo dietaInfoModificado)
        {
            try
            {
                if (dietaInfoModificado.idUsuario > 0 || dietaInfoModificado.imcInicial != string.Empty || dietaInfoModificado.imcActual != string.Empty || dietaInfoModificado.peso != string.Empty
                    || dietaInfoModificado.altura != string.Empty || dietaInfoModificado.naf != string.Empty || dietaInfoModificado.resultado != string.Empty)
                {
                    DietaInfoModel.ModificarDietaInfo(dietaInfoModificado);
                }
                else
                {
                    throw new Exception("No se admiten campos vacios");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message.ToString());
            }
        }
    }
}
