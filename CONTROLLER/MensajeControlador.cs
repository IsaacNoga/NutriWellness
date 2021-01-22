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
                    throw new Exception("Hubo un error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }
        }

        public static List<Mensaje> BuscarMensajeCriterios(string criterios, bool estado)
        {
            try
            {
                return MensajeModel.BuscarMensajeCriterios(criterios, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }
        }

        public static Mensaje BuscarContactoPorID(int idMensaje)
        {
            try
            {
                return MensajeModel.BuscarMensajePorID(idMensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }
        }

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
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }
        }

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
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }
        }
    }
}
