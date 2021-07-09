using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace CONTROLLER
{
    public class PlanControlador
    {
        /// <summary>
        /// Metodo para insertar el plan a la base de datos con los datos
        /// </summary>
        /// <param name="newPlan">PlanNutri Informacion del plan</param>
        public static void InsertarPlan(PlanNutri newPlan)
        {
            try
            {
                PlanModel.InsertarPlan(newPlan);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }
    }
}
