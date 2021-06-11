using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class AlimentosModel
    {
        /// <summary>
        /// Busca directamente en la base de datos si un alimento coincide con los criterios
        /// </summary>
        /// <param name="criterios">string Criterios de busqueda</param>
        /// <returns>Retorna el resultado de la busqueda</returns>
        public static List<Alimento> BuscarAlimentoCriterios(string criterios)
        {
            using (var modelo = new proyectoEntities())
            {
                List<Alimento> resultado =
                    (from al in modelo.Alimentoes where (al.nombre.Contains(criterios) || al.unidad.Contains(criterios) || al.cantidadSu.Contains(criterios)) select al).ToList();
                return resultado;
            }
        }

        /// <summary>
        /// Inserta directamente en la base de datos un nuevo alimento
        /// </summary>
        /// <param name="newAlimento">Alimento Datos del nuevo alimento</param>
        public static void InsertarAlimento(Alimento newAlimento)
        {
            using (var modelo = new proyectoEntities())
            {
                modelo.Alimentoes.Add(newAlimento);
                modelo.SaveChanges();
            }

        }

        /// <summary>
        /// Actualiza directamente en la base de datos la informacion del alimento
        /// </summary>
        /// <param name="alimentoModificado">Alimento Datos del alimento a actualizar</param>
        public static void ModificarAlimento(Alimento alimentoModificado)
        {
            var alimento = new Alimento() { 
                idAlimento = alimentoModificado.idAlimento,
                nombre=alimentoModificado.nombre
            };

            using (var modelo = new proyectoEntities())
            {
                
                modelo.Alimentoes.Attach(alimento);
                modelo.SaveChanges();
            }
        }
    }
}
