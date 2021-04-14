using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class PlanModel
    {
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
