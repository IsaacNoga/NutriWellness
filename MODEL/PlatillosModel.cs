using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class PlatillosModel
    {
        public static List<Platillo> BuscarPlatilloCriterios(string criterios, bool estado)
        {
            using (var modelo = new ProyectoEntities())
            {
                List<Platillo> resultado =
                    (from pl in modelo.Platilloes
                     where (pl.nombre.Contains(criterios) || pl.descripcion.Contains(criterios))
                     && pl.activo == estado
                     select pl).ToList();
                return resultado;
            }
        }

        public static void CambiarEstadoPlatillo(int idPlatillo)
        {
            using (var modelo = new ProyectoEntities())
            {
                var platillo = modelo.Platilloes.Find(idPlatillo);
                //platillo.activo = platillo.activo == true ? false : true;
                if (platillo.activo == true)
                {
                    platillo.activo = false;
                }
                else
                {
                    platillo.activo = true;
                }
                modelo.SaveChanges();
            }
        }
    }
}
