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
	/// Registro de usuarios
	/// </summary>
    public partial class Registro : System.Web.UI.Page
    {
		/// <summary>
		/// Metodo load
		/// </summary>
		/// <param name="sender">Objeto</param>
		/// <param name="e">Argumento de evento</param>
		protected void Page_Load(object sender, EventArgs e)
        {
			
        }

		/// <summary>
		/// Metodo click, Crea el usuario con los datos y los parametros
		/// 
		/// Atraves del controlador conectado al modelo se crea el usuario con los datos en los
		/// campos establecidos, se controla los errores en el controlador.
		/// </summary>
		/// <param name="sender">Objeto</param>
		/// <param name="e">Argumento de evento</param>
		/// <param name="nuevoUsuario">var Guarda los datos del registro para ser insertado como usuario</param>
		/// <param name="nuevoDietaInfo">var Crea los datos del registro para ser insertado en la dieta del usuario</param>
		/// <param name="nuevoPlan">var Guarda los datos del registro para ser insertado en el plan del usuario</param>
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
				
				UsuarioControlador.InsertarUsuario(nuevoUsuario);
				if (UsuarioModel.ExisteUsuario(nuevoUsuario.correo))
                {
					int id = UsuarioModel.idUsuario(nuevoUsuario.correo);
					var nuevoDietaInfo = new MODEL.DietaInfo()
					{
						imcActual = "Sin definir",
						imcInicial = "Sin definir",
						peso = "Sin definir",
						altura = "Sin definir",
						naf = "Sin definir",
						resultado = "Sin definir",
						idUsuario = id
					};
					var nuevoPlan = new MODEL.PlanNutri()
					{
						Desayuno = "Sin asignar",
						Comida = "Sin asignar",
						Cena = "Sin asignar",
						Colaciones = "Sin asignar",
						idUsuario = id
					};
					PlanControlador.InsertarPlan(nuevoPlan);
					DietaInfoControlador.InsertarDietaInfo(nuevoDietaInfo);
				}
				mensaje.Visible = true;
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