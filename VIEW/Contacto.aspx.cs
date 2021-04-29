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
    /// Información de contacto
    /// </summary>
    public partial class contacto : System.Web.UI.Page
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
        /// 
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                var newMensaje = new Mensaje()
                {
                    nombre = txtNombre.Text,
                    correo = txtEmail.Text,
                    telefono = txtTelefono.Text,
                    mensaje1 = txtMensaje.Text,
                    activo = true
                };

                MensajeControlador.InsertarMensaje(newMensaje);
                mensaje.Visible = true;
                string javaScript = "OcultarMensaje();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }
            catch (Exception ex)
            {
                var datos = "<script> alert('" + ex.Message + "') </script>";
                Response.Write(datos);
            }
        }
    }
}