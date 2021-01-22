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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            bool estado;
            if (chbxEstado.SelectedIndex == 0)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            var resultado = MensajeControlador.BuscarMensajeCriterios(txtCriterios.Text, estado);

            gvMensajes.DataSource = resultado;
            gvMensajes.DataBind();
        }

        protected void ImgBtnLeido_Command(object sender, CommandEventArgs e)
        {
            var idMensaje = Convert.ToInt32(e.CommandArgument);

            MensajeControlador.CambiarEstadoMensaje(idMensaje);
            Page_Load(null, null);
        }
    }
}