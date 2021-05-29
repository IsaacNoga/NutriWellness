using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace CONTROLLER
{
    public class MensajeControlador
    {
        /// <summary>
        /// Crea el mensaje y lo inserta en la base de datos
        /// </summary>
        /// <param name="newMensaje">Mensaje Datos del mensaje a insertar</param>
        public static void InsertarMensaje(Mensaje newMensaje)
        {
            try
            {
                if (newMensaje.correo != string.Empty || newMensaje.mensaje1 != string.Empty || newMensaje.nombre != string.Empty)
                {
                    MensajeModel.InsertarMensaje(newMensaje);
                    
                }
                else
                {
                    throw new Exception("No se admiten campos vacios");
                  
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());

            }
           
        }

        /// <summary>
        /// Busca en la base de datos los mensajes atraves de los criterios establecidos
        /// </summary>
        /// <param name="criterios">string Criterios de busqueda</param>
        /// <param name="estado">bool Estado del mensaje</param>
        /// <returns>Retorna los mensajes obtenidos</returns>
        public static List<Mensaje> BuscarMensajeCriterios(string criterios, bool estado)
        {
            try
            {
                return MensajeModel.BuscarMensajeCriterios(criterios, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Busca en la base de datos los mensajes por la ID
        /// </summary>
        /// <param name="idMensaje">int Identificador del mensaje</param>
        /// <returns>Retorna los mensajes obtenidos</returns>
        public static Mensaje BuscarContactoPorID(int idMensaje)
        {
            try
            {
                return MensajeModel.BuscarMensajePorID(idMensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Metodo para guardar la edicion del mensaje
        /// </summary>
        /// <param name="mensajeModificado">Mensaje Datos del mensaje modificado</param>
        public static void Modificarmensaje(Mensaje mensajeModificado)
        {
            try
            {
                if (mensajeModificado.idMensaje > 0 && mensajeModificado.nombre != string.Empty && mensajeModificado.correo != string.Empty)
                {
                    MensajeModel.ModificarMensaje(mensajeModificado);
                }
                else
                {
                    throw new Exception("Hubo un error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Metodo para cambiar el estado del mensaje activo-innactivo
        /// </summary>
        /// <param name="idMensaje">int Identificador del mensaje</param>
        public static void CambiarEstadoMensaje(int idMensaje)
        {
            try
            {
                if (idMensaje > 0)
                {
                    MensajeModel.CambiarEstadoMensaje(idMensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

      
    }
}
