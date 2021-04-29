using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CONTROLLER;

namespace VIEW.User
{
    public partial class Platillos : System.Web.UI.Page
    {
        /// <summary>
        /// Carga de la página 
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsularImagen(); //Se ejecuta el metodo al cargar la pagina
        }

        /// <summary>
        /// Metodo donde se carga un GV con la información de los platillos en el GV
        /// </summary>
        /// <param name="resultado">var Guarda el resultado de la consulta</param>
        public void ConsularImagen()
        {
            try
            {
                var resultado = PlatillosControlador.BuscarPlatilloCriterios(txtCriterios.Text, true);

                Repeater1.DataSource = resultado;
                Repeater1.DataBind();
            }
            catch (Exception ex)
            {
                mensajeError.Visible = true;
                mensajeError.InnerText = ex.Message;
            }
        }
    }
}