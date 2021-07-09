using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class DietaInfoModel
    {
        /// <summary>
        /// Inserta directamente en la base de datos la informacion de la dieta
        /// </summary>
        /// <param name="newDietaInfo">DietaInfo Datos de la dieta</param>
        public static void InsertarDietaInfo(DietaInfo newDietaInfo)
        {
            using (var modelo = new proyectoEntities())
            {
                modelo.DietaInfoes.Add(newDietaInfo);
                modelo.SaveChanges();
            }

        }

        /// <summary>
        /// Actualiza directamente en la base de datos la informacion de la dieta
        /// </summary>
        /// <param name="dietaInfoModificado">DietaInfo Informacion de la dieta a actualizar</param>
        public static void ModificarDietaInfo(DietaInfo dietaInfoModificado)
        {
            var dieta = new DietaInfo() {  idInfo = dietaInfoModificado.idInfo };

            using (var modelo = new proyectoEntities())
            {
                modelo.DietaInfoes.Attach(dieta);
                dieta = dietaInfoModificado;
                modelo.SaveChanges();
            }
        }
    }
}
