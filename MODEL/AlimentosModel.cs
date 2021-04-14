using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class AlimentosModel
    {
        public static List<Alimento> BuscarAlimentoCriterios(string criterios)
        {
            using (var modelo = new ProyectoEntities())
            {
                List<Alimento> resultado =
                    (from al in modelo.Alimentoes where (al.nombre.Contains(criterios) || al.unidad.Contains(criterios) || al.cantidadSu.Contains(criterios)) select al).ToList();
                return resultado;
            }
        }

        public static void InsertarAlimento(Alimento newAlimento)
        {
            using (var modelo = new ProyectoEntities())
            {
                modelo.Alimentoes.Add(newAlimento);
                modelo.SaveChanges();
            }

        }

        public static void ModificarAlimento(Alimento alimentoModificado)
        {
            var alimento = new Alimento() { 
                idAlimento = alimentoModificado.idAlimento,
                nombre=alimentoModificado.nombre
            };

            using (var modelo = new ProyectoEntities())
            {
                
                modelo.Alimentoes.Attach(alimento);
                modelo.SaveChanges();
            }
        }
    }
}
