using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class CitaModel
    {
        public static void InsertarCita(Cita newCita)
        {
            using (var modelo = new proyectoEntities())
            {
                modelo.Citas.Add(newCita);
                modelo.SaveChanges();
            }

        }
        /// <summary>
        /// Busca directamente en la base de datos si una cita concuerda con los criterios
        /// </summary>
        /// <param name="criterios">stirng Criterios de busqueda</param>
        /// <param name="estado">bool estado del platillo</param>
        /// <returns>Retorna el resultado de la busqueda</returns>
        public static List<Cita> BuscarCita(string criterios, bool estado)
        {
            using (var modelo = new proyectoEntities())
            {
                List<Cita> resultado =
                    (from us in modelo.Citas
                     where (us.Usuario.nombre.Contains(criterios) ||
                     us.Usuario.correo.Contains(criterios) ||
                     us.Usuario.aPaterno.Contains(criterios) ||
                     us.Usuario.aMaterno.Contains(criterios)) && 
                     us.activo == estado
                     select us).ToList();
                return resultado;
            }
        }

        /// <summary>
        /// Actualiza directamente en la base de datos la informacion de la cita
        /// </summary>
        /// <param name="idCita">int Identificador de la cita</param>
        public static void CambiarEstadoCita(int idCita)
        {
            using (var modelo = new proyectoEntities())
            {
                var cita = modelo.Citas.Find(idCita);
                if (cita.activo == true)
                {
                    cita.activo = false;
                }
                else
                {
                    cita.activo = true;
                }
                modelo.SaveChanges();
            }
        }
    }
}
