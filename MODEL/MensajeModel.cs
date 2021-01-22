using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class MensajeModel
    {
        public static void InsertarMensaje(Mensaje newContacto)
        {
            try
            {
                using (var modelo = new ProyectoEntities())
                {
                    modelo.Mensajes.Add(newContacto);
                    modelo.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }
        }

        public static List<Mensaje> BuscarMensajeCriterios(string criterios, bool estado)
        {
            using (var modelo = new ProyectoEntities())
            {
                List<Mensaje> resultado =
                    (from msj in modelo.Mensajes
                     where (msj.correo.Contains(criterios)||msj.mensaje1.Contains(criterios))
                     && msj.activo == estado
                     select msj).ToList();
                return resultado;
            }
        }

        public static Mensaje BuscarMensajePorID(int idMensaje)
        {
            using (var modelo = new ProyectoEntities())
            {
                var resultado = (from msj in modelo.Mensajes
                                 where msj.idMensaje == idMensaje
                                 select msj).FirstOrDefault();
                return resultado;
            }
        }

        public static void ModificarMensaje(Mensaje mensajeModificado)
        {
            var contact = new Mensaje() { idMensaje = mensajeModificado.idMensaje };

            using (var modelo = new ProyectoEntities())
            {
                modelo.Mensajes.Attach(contact);
                contact = mensajeModificado;
                modelo.SaveChanges();
            }
        }

        public static void CambiarEstadoMensaje(int idMensaje)
        {
            using (var modelo = new ProyectoEntities())
            {
                var elmensaje = modelo.Mensajes.Find(idMensaje);
                //elmensaje.activo = elmensaje.activo == true ? false : true;
                if (elmensaje.activo == true)
                {
                    elmensaje.activo = false;
                }
                else
                {
                    elmensaje.activo = true;
                }
                modelo.SaveChanges();
            }
        }
    }
}
