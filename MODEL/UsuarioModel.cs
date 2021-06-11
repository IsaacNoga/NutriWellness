using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class UsuarioModel
    {
        /// <summary>
        /// Inserta directamente en la base de datos la informacion de registro de usuario
        /// </summary>
        /// <param name="newUsuario">Usuario datos del usuario a registrar</param>
        public static void InsertarUsuario(Usuario newUsuario)
        {
            using (var modelo = new proyectoEntities())
            {
                modelo.Usuarios.Add(newUsuario);
                modelo.SaveChanges();
            }

        }
        /// <summary>
        /// Busca directamente en la base de datos si un usuario coincide con los criterios
        /// </summary>
        /// <param name="criterios">string Criterios para la busqueda</param>
        /// <param name="estado">bool Estado del usuario</param>
        /// <returns>Retorna los datos del usuario</returns>
        public static List<Usuario> BuscarUsuarioCriterios(string criterios, bool estado)
        {
            using (var modelo = new proyectoEntities())
            {
                List<Usuario> resultado =
                    (from us in modelo.Usuarios
                     where (us.idUsuario.ToString().Contains(criterios)||us.nombre.Contains(criterios) || us.correo.Contains(criterios) || us.aPaterno.Contains(criterios) || us.aMaterno.Contains(criterios))
                     && us.activo == estado
                     select us).ToList();
                return resultado;
            }
        }

        public static Usuario BuscarIdUsuario(string correo)
        {
            using (var modelo = new proyectoEntities())
            {
                Usuario resultado = (Usuario)(from us in modelo.Usuarios where us.correo.Contains(correo) select us.idUsuario);
                return resultado;
            }
        }

        /// <summary>
        /// Actualiza directamente en la base de datos la informacion del usuario
        /// </summary>
        /// <param name="usuarioModificado">Usuario Datos del usuario actualizados</param>
        public static void ModificarUsuario(Usuario usuarioModificado)
        {
            var user = new Usuario() { idUsuario = usuarioModificado.idUsuario };

            using (var modelo = new proyectoEntities())
            {
                modelo.Usuarios.Attach(user);
                user = usuarioModificado;
                modelo.SaveChanges();
            }
        }

        /// <summary>
        /// Cambia directamente en la base de datos el estado del usuario
        /// </summary>
        /// <param name="idUsuario">int Identificador del usuario</param>
        public static void CambiarEstadoUsuario(int idUsuario)
        {
            using (var modelo = new proyectoEntities())
            {
                var usuario = modelo.Usuarios.Find(idUsuario);
                usuario.activo = usuario.activo == true ? false : true;
                modelo.SaveChanges();
            }
        }

        /// <summary>
        /// Consulta directamente en la base de datos si el usuario que desea ingresar existe
        /// </summary>
        /// <param name="usuario">Usuario datos de inicio de sesion</param>
        /// <returns>Retorna la respuesta</returns>
        public static Usuario IngresarSistema(Usuario usuario)
        {
            try
            {
                using (var modelo = new proyectoEntities())
                {
                    var resultado = (from us in modelo.Usuarios
                                     where (us.contrasena == usuario.contrasena
                                     && us.correo == usuario.correo)
                                     && us.activo == true
                                     select us).FirstOrDefault();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message.ToString());
            }

        }

        /// <summary>
        /// Verifica directamente en la base de datos si el usuario existe
        /// </summary>
        /// <param name="correo">string correo del usuario</param>
        /// <returns>Retorna una respuesta</returns>
        public static bool ExisteUsuario(string correo)
        {
            using (var modelo = new proyectoEntities())
            {
                var resultado = (from us in modelo.Usuarios
                                 where us.correo == correo
                                 select us);
                return resultado.Count() > 0 ? true : false;
            }
        }

        public static int idUsuario(string correo)
        {
            using (var modelo = new proyectoEntities())
            {
                var resultado = (from user in modelo.Usuarios where (user.correo == correo) select user.idUsuario).FirstOrDefault();
                return resultado;
            }
        }
    }
}
