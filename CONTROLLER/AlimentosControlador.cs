using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace CONTROLLER
{
    public class AlimentosControlador
    {
        //Buscador de alimentos a traves de los criterios
        public static List<Alimento> BuscarAlimentoCriterios(string criterios)
        {
            try
            {
                return AlimentosModel.BuscarAlimentoCriterios(criterios);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message.ToString());
            }
        }

        //Inserta el alimento creado en la base de datos a traves del modelo
        public static void InsertarAlimento(Alimento newAlimento)
        {
            try
            {
                if (newAlimento.nombre!=String.Empty||newAlimento.potasio != String.Empty ||newAlimento.hierro != String.Empty 
                    ||newAlimento.acidoFolico != String.Empty ||newAlimento.vitmaminaA != String.Empty ||newAlimento.fibra != String.Empty 
                    ||newAlimento.pesoBruto != String.Empty ||newAlimento.pesoNeto != String.Empty ||newAlimento.energia != String.Empty 
                    ||newAlimento.protenia != String.Empty ||newAlimento.lipidos != String.Empty ||newAlimento.hidratosDC != String.Empty 
                    ||newAlimento.cargaGlic != String.Empty ||newAlimento.indiceGlic != String.Empty ||newAlimento.unidad != String.Empty 
                    ||newAlimento.cantidadSu != String.Empty)
                {
                    AlimentosModel.InsertarAlimento(newAlimento);
                }
                else
                {
                    throw new Exception("No se admiten campos vacios.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message.ToString());
            }
        }
        
        //Actualiza la información del alimento a traves del modelo
        public static void ModificarAlimento(Alimento alimentoModificado)
        {
            try
            {
                if (alimentoModificado.nombre != string.Empty)
                {
                    AlimentosModel.ModificarAlimento(alimentoModificado);
                }
                else
                {
                    throw new Exception("No se admiten campos vacios ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errror: " + ex.Message.ToString());
            }
        }
    }
}
