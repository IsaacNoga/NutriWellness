using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CONTROLLER;
using MODEL;
using System.Data;
using System.Data.SqlClient;


namespace VIEW.Control
{
    public partial class Usuarios : System.Web.UI.Page
    {
        double DiasAño = 335.25;
        /// <summary>
        /// Carga de la página 
        /// 
        /// Al cargar la pagina, se llena el GridView con la información de los usuarios
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var resultado = UsuarioControlador.BuscarUsuarioCriterios(string.Empty, true);

            gvUsuarios.DataSource = resultado;
            gvUsuarios.DataBind();
        }

        /// <summary>
        /// Metodo click para buscar usuarios
        /// 
        /// Al hacer click en el boton buscar, toma los datos de los criterios y busca coincidencia
        /// de los usuarios atraves del controlador conectado al modelo, si un error ocurre, se muestra
        /// el mensaje de error correspondiente atraves del try-catch
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        /// <param name="estado">bool Comprueba el estado de la consulta</param>
        /// <param name="resultado">var Guarda el resultado de la consulta</param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                bool estado;
                if (chbxEstado.SelectedIndex == 0) estado = true;
                else estado = false;

                var resultado = UsuarioControlador.BuscarUsuarioCriterios(txtCriterios.Text, estado);

                gvUsuarios.DataSource = resultado;
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
            }
        }

        /// <summary>
        /// Metodo comando, cambia el estado del usuario
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        /// <param name="idUsuario">var Guarda la id de usuario para realizar la consulta</param>
        protected void ImgBtnEliminar_Command(object sender, CommandEventArgs e)
        {
            var idUsuario = Convert.ToInt32(e.CommandArgument);

            UsuarioControlador.CambiarEstadoUsuario(idUsuario);
            Page_Load(null, null);
        }

        /// <summary>
        /// Metodo comando, Muestra el panel para editar al usuario
        /// 
        /// Toma la id de usuario y rellena las celdas con los datos del usuario para
        /// permitir la modificacion de estos datos
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void ImgBtnModificar_Command(object sender, CommandEventArgs e)
        {
            pnlEditar.Visible = true;
            GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent;
            gvUsuarios.SelectedIndex = row.RowIndex;
            txtId.Text = row.Cells[0].Text;
            txtNombre.Text = row.Cells[1].Text;
            txtApellido1.Text = row.Cells[2].Text;
            txtApellido2.Text = row.Cells[3].Text;
            txtCorreo.Text = row.Cells[4].Text;
            txtTelefono.Text = row.Cells[5].Text;
        }

        /// <summary>
        /// Metodo click, Modifica la informacion del usuario
        /// 
        /// Despues de editar la informacion del usuario, se cambian sus datos por
        /// los contenidos en las celdas
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        /// <param name="resultado">var Guarda el resultado de la consulta</param>
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtNombre.Text)|| String.IsNullOrEmpty(txtApellido1.Text) || 
                    String.IsNullOrEmpty(txtApellido2.Text) || String.IsNullOrEmpty(txtCorreo.Text) || 
                    String.IsNullOrEmpty(txtTelefono.Text))
                {
                    lblError.Text = "Error: Todos los campos deben ser llenados"; //Texto del error si algún dato está vacio
                    mensajeError.Visible = true;
                }
                else
                {
                    string CadenaConexion = "Data source=localhost;initial catalog=Proyecto;integrated Security=True";
                    SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE Usuario SET nombre=@nombre, aPaterno=@aPaterno, " +
                                      "aMaterno=@aMaterno, correo=@correo, telefono=@telefono " +
                                      "WHERE idUsuario=@idUsuario";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = txtId.Text;
                    cmd.Parameters.Add("@nombre", SqlDbType.Text).Value = txtNombre.Text;
                    cmd.Parameters.Add("@aPaterno", SqlDbType.Text).Value = txtApellido1.Text;
                    cmd.Parameters.Add("@aMaterno", SqlDbType.Text).Value = txtApellido2.Text;
                    cmd.Parameters.Add("@correo", SqlDbType.Text).Value = txtCorreo.Text;
                    cmd.Parameters.Add("@telefono", SqlDbType.Text).Value = txtTelefono.Text;
                    cmd.Connection = conexionSQL;
                    conexionSQL.Open();
                    cmd.ExecuteNonQuery();

                    pnlEditar.Visible = false;
                    var resultado = UsuarioControlador.BuscarUsuarioCriterios(string.Empty, true);

                    gvUsuarios.DataSource = resultado;
                    gvUsuarios.DataBind(); //Llena el GV con la información
                }
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
        }

        /// <summary>
        /// Metodo para calcular la edad del usuario
        /// </summary>
        /// <param name="fechaNacimiento"></param>
        /// <returns>Calcula y regresa el valor de la edad del usuario registrado</returns>
        /*
        protected int CalculateAge(DateTime fechaNacimiento)
        {
            return (int)((double)new TimeSpan(DateTime.Now.Subtract(fechaNacimiento).Ticks).Days / DiasAño);
        }
        */
    }
}