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
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                var newUsuario = new MODEL.Medico()
                {
                    contrasena = txtContrasena.Text,
                    correo = txtEmail.Text
                };
                var medico = MedicoControlador.IngresarSistema(newUsuario);
                Session.Timeout = 60;
                Session["nombre"] = medico.nombre + " " + medico.aPaterno;
                Session["idUsuario"] = medico.idMedico;


                Response.Redirect("~/Control/Usuarios.aspx");
            }
            catch (Exception ex)
            {
                mensajeError.Visible = true;
                mensajeError.InnerText = ex.Message;

                string javaScript = "OcultarMensaje();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }
        }
    }
}