using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class UsuarioModel
    {
        public static void InsertarUsuario(Usuario newUsuario)
        {
            using (var modelo = new ProyectoEntities())
            {
                modelo.Usuarios.Add(newUsuario);
                modelo.SaveChanges();
            }

        }

        public static List<Usuario> BuscarUsuarioCriterios(string criterios, bool estado)
        {
            using (var modelo = new ProyectoEntities())
            {
                List<Usuario> resultado =
                    (from us in modelo.Usuarios
                     where (us.nombre.Contains(criterios) || us.correo.Contains(criterios) || us.aPaterno.Contains(criterios) || us.aMaterno.Contains(criterios))
                     && us.activo == estado
                     select us).ToList();
                return resultado;
            }
        }

        public static void ModificarUsuario(Usuario usuarioModificado)
        {
            var user = new Usuario() { idUsuario = usuarioModificado.idUsuario };

            using (var modelo = new ProyectoEntities())
            {
                modelo.Usuarios.Attach(user);
                user = usuarioModificado;
                modelo.SaveChanges();
            }
        }

        public static void CambiarEstadoUsuario(int idUsuario)
        {
            using (var modelo = new ProyectoEntities())
            {
                var usuario = modelo.Usuarios.Find(idUsuario);
                usuario.activo = usuario.activo == true ? false : true;
                modelo.SaveChanges();
            }
        }

        public static Usuario IngresarSistema(Usuario usuario)
        {
            try
            {
                using (var modelo = new ProyectoEntities())
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
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }

        }

        public static bool ExisteUsuario(string correo)
        {
            using (var modelo = new ProyectoEntities())
            {
                var resultado = (from us in modelo.Usuarios
                                 where us.correo == correo
                                 select us);
                return resultado.Count() > 0 ? true : false;
            }
        }
    }
}
