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
            using (var modelo = new ProyectoEntities())
            {
                modelo.Citas.Add(newCita);
                modelo.SaveChanges();
            }

        }
        public static List<Cita> BuscarCita(string criterios, bool estado)
        {
            using (var modelo = new ProyectoEntities())
            {
                List<Cita> resultado =
                    (from us in modelo.Citas
                     where (us.Usuario.nombre.Contains(criterios) || us.Usuario.correo.Contains(criterios) || us.Usuario.aPaterno.Contains(criterios) || us.Usuario.aMaterno.Contains(criterios)) && us.activo == estado
                     select us).ToList();
                return resultado;
            }
        }

        public static void CambiarEstadoCita(int idCita)
        {
            using (var modelo = new ProyectoEntities())
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
