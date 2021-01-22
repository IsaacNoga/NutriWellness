using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VIEW
{
    public partial class Usuario : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var nombre = Session["nombre"];
            var id = Session["idUsuario"];
            if (nombre == null || id == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            lblUsuarioLog.Text = nombre.ToString();
        }
    }
}