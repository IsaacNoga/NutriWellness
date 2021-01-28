using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace CONTROLLER
{
    public class UsuarioControlador
    {
        public static void InsertarUsuario(Usuario newUsuario)
        {
            try
            {
                if (newUsuario.correo != string.Empty && newUsuario.contrasena != string.Empty
                    && newUsuario.nombre != string.Empty && newUsuario.aMaterno != string.Empty && newUsuario.aPaterno != string.Empty && 
                    newUsuario.telefono != string.Empty && UsuarioModel.ExisteUsuario(newUsuario.correo) != true)
                {
                    UsuarioModel.InsertarUsuario(newUsuario);
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

        public static List<Usuario> BuscarUsuarioCriterios(string criterios, bool estado)
        {
            try
            {
                return UsuarioModel.BuscarUsuarioCriterios(criterios, estado);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        public static void ModificarUsuario(Usuario usuarioModificado)
        {
            try
            {
                if (usuarioModificado.idUsuario > 0 && usuarioModificado.nombre != string.Empty && usuarioModificado.correo != string.Empty && usuarioModificado.contrasena != string.Empty)
                {
                    UsuarioModel.ModificarUsuario(usuarioModificado);
                }
                else
                {
                    throw new Exception("Hubo un con el usuario");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        public static void CambiarEstadoUsuario(int idUsuario)
        {
            try
            {
                if (idUsuario > 0)
                {
                    UsuarioModel.CambiarEstadoUsuario(idUsuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        public static Usuario IngresarSistema(Usuario usuario)
        {
            try
            {
                if (usuario.correo != string.Empty && usuario.contrasena != string.Empty)
                {
                    var resultado = UsuarioModel.IngresarSistema(usuario);
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
                    throw new Exception("No se admiten campos vacios.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }
    }
}
