using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class PlanModel
    {
        /// <summary>
        /// Inserta directamente en la base de datos la informacion del plan
        /// </summary>
        /// <param name="newPlan">PlanNutri Informacion nutricional del usuario</param>
        public static void InsertarPlan(PlanNutri newPlan)
        {
            using (var modelo = new ProyectoEntities())
            {
                modelo.PlanNutris.Add(newPlan);
                modelo.SaveChanges();
            }

        }
    }
}
