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
    /// Página principal de la pagina
    /// </summary>
    public partial class Inicio : System.Web.UI.Page
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
        /// Metodo click, envia el mensaje
        /// 
        /// Crea el mensaje y lo inserta en la base de datos atraves del
        /// controlador conectado al modelo.
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        /// <param name="newMensaje">var Crea el mensaje con los datos escritos</param>
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
                txtNombre.Text = "";
                txtEmail.Text = "";
                txtTelefono.Text = "";
                txtMensaje.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
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
            mensaje.Visible = false;
        }
    }
}