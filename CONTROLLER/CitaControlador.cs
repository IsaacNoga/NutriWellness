using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace CONTROLLER
{
    public class CitaControlador
    {

        /// <summary>
        /// Crea la cita y la inserta en la base de datos con los datos de la cita, se controla datos invalidos
        /// </summary>
        /// <param name="newCita">Cita Datos de la cita a insertar</param>
        public static void InsertarCita(Cita newCita)
        {
            try
            {
                if (newCita.idUsuario!=null || newCita.hora !=null || newCita.fecha != null)
                {
                    CitaModel.InsertarCita(newCita);
                }
                else
                {
                    throw new Exception("Los datos de los campos son invalidos.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Buscador de cita mediante los criterios establecidos
        /// </summary>
        /// <param name="criterios">string Criterios de busqueda</param>
        /// <param name="estado">bool Estado de la cita</param>
        /// <returns></returns>
        public static List<Cita> BuscarCitaCriterios(string criterios, bool estado)
        {
            try
            {
                return CitaModel.BuscarCita(criterios, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }
    }
}
