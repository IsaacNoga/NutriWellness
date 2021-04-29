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
        /// <summary>
        /// Inserta al nuevo usuario a la base de datos con sus datos
        /// </summary>
        /// <param name="newUsuario">Usuario Datos del nuevo usuario a insertar</param>
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
                    throw new Exception("Todos los campos deben ser llenados.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error: " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Buscador de usuarios atraves de los critertios
        /// </summary>
        /// <param name="criterios">string Criterios de busqueda</param>
        /// <param name="estado">bool Estado del usuario</param>
        /// <returns></returns>
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

        /// <summary>
        /// Actualiza atraves del modelo los datos del usuario
        /// </summary>
        /// <param name="usuarioModificado">Usuario Datos del usuario a actualizar</param>
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

        /// <summary>
        /// Cambia el estado del usuario activo-innactivo
        /// </summary>
        /// <param name="idUsuario">int Numero de identificador del usuario</param>
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

        /// <summary>
        /// Comprueba los datos para iniciar sesion
        /// </summary>
        /// <param name="usuario">Usuario datos del usuario</param>
        /// <returns>Regresa una respuesta si el usuario existe o no</returns>
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
