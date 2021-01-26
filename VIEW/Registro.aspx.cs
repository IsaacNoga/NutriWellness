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
					nacimiento = Convert.ToDateTime(txtNacimiento.Text),
					idGenero = ddlGenero.SelectedIndex+1
				};

				var nuevoDietaInfo = new MODEL.DietaInfo()
				{
					imcActual = "Sin definir",
					imcInicial = "Sin definir",
					peso = "Sin definir",
					altura = "Sin definir",
					naf = "Sin definir",
					resultado = "Sin definir",
				};

				var nuevoPlan = new MODEL.PlanNutri()
				{
					Desayuno="Sin asignar",
					Comida= "Sin asignar",
					Cena= "Sin asignar",
					Colaciones= "Sin asignar"
				};
				DietaInfoControlador.InsertarDietaInfo(nuevoDietaInfo);
				UsuarioControlador.InsertarUsuario(nuevoUsuario);
				PlanControlador.InsertarPlan(nuevoPlan);
				
				mensaje.Visible = true;
				string javaScript = "OcultarMensaje();";
				ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
			}
			catch (Exception ex)
			{
				lblError.Text = ex.Message;
				mensajeError.Visible = true;
				string javaScript = "OcultarMensajeError();";
				ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
			}
		}

        protected void btnError_Click(object sender, EventArgs e)
        {
			mensajeError.Visible = false;
			mensaje.Visible = false;
        }
    }
}