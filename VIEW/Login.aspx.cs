using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL;
using CONTROLLER;

namespace VIEW
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                var newUsuario = new MODEL.Usuario()
                {
                    contrasena = txtContrasena.Text,
                    correo = txtEmail.Text
                };
                var usuario = UsuarioControlador.IngresarSistema(newUsuario);
                Session.Timeout = 20;
                Session["nombre"] = usuario.nombre + " " + usuario.aPaterno;
                Session["idUsuario"] = usuario.idUsuario;


                Response.Redirect("~/User/Citas.aspx");
            }
            catch (Exception ex)
            {
                mensajeError.Visible = true;
                mensajeError.InnerText = ex.Message;

                string javaScript = "OcultarMensajeError();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }
        }
    }
}