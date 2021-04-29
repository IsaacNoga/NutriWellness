using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL;
using CONTROLLER;

namespace VIEW.Control
{
    public partial class Mensajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodo click, buscar los mensajes al momento de dar click en el boton
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        /// <param name="estado">bool Comprueba el estado de la consulta</param>
        /// <param name="resultado">var Guarda el resultado de la consulta</param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            bool estado;
            if (chbxEstado.SelectedIndex == 0) //Si el estado es el inicial
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            //Se utilizan la iformación esctrita en el textbox para buscar los mensajes
            var resultado = MensajeControlador.BuscarMensajeCriterios(txtCriterios.Text, estado);

            gvMensajes.DataSource = resultado;
            gvMensajes.DataBind(); //Llena el GV con la información
        }

        /// <summary>
        /// Metodo comando, se llama cuando se ejecuta el comando de la confirmación de lectura
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void ImgBtnLeido_Command(object sender, CommandEventArgs e)
        {
            var idMensaje = Convert.ToInt32(e.CommandArgument);

            MensajeControlador.CambiarEstadoMensaje(idMensaje); //Cambia el estado del mensaje con su id
            Page_Load(null, null);
        }
    }
}