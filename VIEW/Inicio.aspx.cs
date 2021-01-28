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
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

        protected void btnError_Click(object sender, EventArgs e)
        {
            mensajeError.Visible = false;
            mensaje.Visible = false;
        }
    }
}