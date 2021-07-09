using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace CONTROLLER
{
    public class MedicoControlador
    {
        /// <summary>
        /// Metodo para iniciar sesion como usuario administrador
        /// </summary>
        /// <param name="usuario">Medico Datos del usuario a ingresar</param>
        /// <returns>Retorna si el usuario existe o no para inicar sesion</returns>
        public static Medico IngresarSistema(Medico usuario)
        {
            try
            {
                if (usuario.correo != string.Empty && usuario.contrasena != string.Empty)
                {
                    var resultado = MedicoModel.IngresarSistema(usuario);
                    if (resultado != null)
                    {
                        return resultado;
                    }
                    else
                    {
                        throw new Exception("Usuario y/o contraseña incorrectos");
                    }
                }
                else
                {
                    throw new Exception("Los datos ingresados no son validos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }
    }
}
