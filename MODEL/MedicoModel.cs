using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class MedicoModel
    {
        /// <summary>
        /// Busca directamente en la base de datos si el usuario administrador existe
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static Medico IngresarSistema(Medico usuario)
        {
            try
            {
                using (var modelo = new proyectoEntities())
                {
                    var resultado = (from us in modelo.Medicos
                                     where (us.contrasena == usuario.contrasena
                                     && us.correo == usuario.correo)
                                     select us).FirstOrDefault();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error en la capa del Modelo: " + ex.Message.ToString());
            }

        }
    }
}
