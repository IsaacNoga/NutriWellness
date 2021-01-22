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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
			try
			{
				var nuevoUsuario = new MODEL.Usuario()
				{
					nombre = txtNombre.Text,
					aPaterno = txtaPaterno.Text,
					aMaterno = txtaMaterno.Text,
					correo = txtCorreo.Text,
					contrasena = txtContrasena.Text,
					telefono = txtTelefono.Text,
					activo = true,
					nacimiento = Convert.ToDateTime(txtNacimiento.Text)
				};

				UsuarioControlador.InsertarUsuario(nuevoUsuario);
				mensaje.Visible = true;
				string javaScript = "OcultarMensaje();";
				ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
			}
			catch (Exception ex)
			{
				mensajeError.InnerText = ex.Message;
				mensajeError.Visible = true;
				string javaScript = "OcultarMensajeError();";
				ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
			}
		}
    }
}