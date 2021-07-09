using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VIEW
{
    /// <summary>
    /// Página maestra, panel de usuario
    /// </summary>
    public partial class Usuario : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Metodo load, restringe el acceso sin una sesion iniciada
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        /// <param name="nombre">var Nombre del usuario</param>
        /// <param name="id">var Id del usuario</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var nombre = Session["nombre"];
            var id = Session["idUsuario"];
            if (nombre == null || id == null) Response.Redirect("~/Login.aspx");
            lblUsuarioLog.Text = "Se le da la bienvenida " + nombre.ToString();
        }

        protected void SalirLink_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Index.aspx");
        }
    }
}