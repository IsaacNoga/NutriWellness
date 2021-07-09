using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class MensajeModel
    {
        /// <summary>
        /// Inserta directamente en la base de datos el mensaje
        /// </summary>
        /// <param name="newContacto">Mensaje Datos del mensaje</param>
        public static void InsertarMensaje(Mensaje newContacto)
        {
            try
            {
                using (var modelo = new proyectoEntities())
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

        /// <summary>
        /// Busca directamente en la base de datos si un mensaje coincide con los criterios
        /// </summary>
        /// <param name="criterios">stirng Criterios de busqueda</param>
        /// <param name="estado">bool estado del platillo</param>
        /// <returns>Retorna el resultado de la busqueda</returns>
        public static List<Mensaje> BuscarMensajeCriterios(string criterios, bool estado)
        {
            using (var modelo = new proyectoEntities())
            {
                List<Mensaje> resultado =
                    (from msj in modelo.Mensajes
                     where (msj.correo.Contains(criterios)||msj.mensaje1.Contains(criterios))
                     && msj.activo == estado
                     select msj).ToList();
                return resultado;
            }
        }

        /// <summary>
        /// Busca directamente en la base de datos si un mensaje coincide con la id
        /// </summary>
        /// <param name="idMensaje">int Identificador del mensaje</param>
        /// <returns>Rtorna la respuesta de la busqueda</returns>
        public static Mensaje BuscarMensajePorID(int idMensaje)
        {
            using (var modelo = new proyectoEntities())
            {
                var resultado = (from msj in modelo.Mensajes
                                 where msj.idMensaje == idMensaje
                                 select msj).FirstOrDefault();
                return resultado;
            }
        }
        /// <summary>
        /// Actualiza directamente en la base de datos la informacion del mensaje
        /// </summary>
        /// <param name="mensajeModificado">Mensaje Datos del mensaje</param>
        public static void ModificarMensaje(Mensaje mensajeModificado)
        {
            var contact = new Mensaje() { idMensaje = mensajeModificado.idMensaje };

            using (var modelo = new proyectoEntities())
            {
                modelo.Mensajes.Attach(contact);
                contact = mensajeModificado;
                modelo.SaveChanges();
            }
        }
        /// <summary>
        /// Actualiza directamente en la base de datos el estado del mensaje
        /// </summary>
        /// <param name="idMensaje">int Identificador del mensaje</param>
        public static void CambiarEstadoMensaje(int idMensaje)
        {
            using (var modelo = new proyectoEntities())
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
