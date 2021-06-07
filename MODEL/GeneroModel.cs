using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class GeneroModel
    {
        public static Genero InsertarGenero(Genero newGenero)
        {
            using (var modelo = new ProyectoEntities())
            {
                newGenero = modelo.Generoes.Add(newGenero);
                modelo.SaveChanges();
            }
            return newGenero;
        }
    }
}
