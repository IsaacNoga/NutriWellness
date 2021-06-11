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
    /// <summary>
    /// Login de administrador
    /// </summary>
    public partial class LoginAdmin : System.Web.UI.Page
    {
        /// <summary>
        /// Metodo load, restringe el acceso sin una sesion iniciada
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodo click, comprueba los datos de inicio de sesion
        /// 
        /// Busca en la base de datos si los datos ingresados son validos 
        /// y redirige al panel de administracion correspondiente
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        /// <param name="newUsuario">var Guarda los datos de usuario para comprobarlos</param>
        /// <param name="medico">var Guarda los datos de la sesion</param>
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
                lblError.Text = ex.Message;
                mensajeError.Visible = true;

                string javaScript = "OcultarMensaje();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }
        }

        /// <summary>
		/// Metodo click, Cerrar el error
		/// 
		/// Al mostrar el error, este se muestra con este boton, al hacer click
		/// se cierra el error
		/// </summary>
		/// <param name="sender">Objeto</param>
		/// <param name="e">Argumento de evento</param>
        protected void btnError_Click(object sender, EventArgs e)
        {
            mensajeError.Visible = false;
        }
    }
}