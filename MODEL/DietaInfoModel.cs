using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class DietaInfoModel
    {
        public static void InsertarDietaInfo(DietaInfo newDietaInfo)
        {
            using (var modelo = new ProyectoEntities())
            {
                modelo.DietaInfoes.Add(newDietaInfo);
                modelo.SaveChanges();
            }

        }

        public static void ModificarDietaInfo(DietaInfo dietaInfoModificado)
        {
            var dieta = new DietaInfo() {  idInfo = dietaInfoModificado.idInfo };

            using (var modelo = new ProyectoEntities())
            {
                modelo.DietaInfoes.Attach(dieta);
                dieta = dietaInfoModificado;
                modelo.SaveChanges();
            }
        }
    }
}
