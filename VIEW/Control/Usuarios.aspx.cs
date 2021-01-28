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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var resultado = UsuarioControlador.BuscarUsuarioCriterios(string.Empty, true);

            gvUsuarios.DataSource = resultado;
            gvUsuarios.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                bool estado;
                if (chbxEstado.SelectedIndex == 0)
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }

                var resultado = UsuarioControlador.BuscarUsuarioCriterios(txtCriterios.Text, estado);

                gvUsuarios.DataSource = resultado;
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
                string javaScript = "OcultarMensajeError();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }
        }

        protected void ImgBtnEliminar_Command(object sender, CommandEventArgs e)
        {
            var idUsuario = Convert.ToInt32(e.CommandArgument);

            UsuarioControlador.CambiarEstadoUsuario(idUsuario);
            Page_Load(null, null);
        }

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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtNombre.Text)|| String.IsNullOrEmpty(txtApellido1.Text) || String.IsNullOrEmpty(txtApellido2.Text) || String.IsNullOrEmpty(txtCorreo.Text) || String.IsNullOrEmpty(txtTelefono.Text))
                {
                    lblError.Text = "Error: Todos los campos deben ser llenados";
                    mensajeError.Visible = true;
                }
                else
                {
                    string CadenaConexion = "Data source=localhost;initial catalog=Proyecto;integrated Security=True";
                    SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE Usuario SET nombre=@nombre, aPaterno=@aPaterno, aMaterno=@aMaterno, correo=@correo, telefono=@telefono WHERE idUsuario=@idUsuario";
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
                    gvUsuarios.DataBind();
                }
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
        }

        protected int CalculateAge(DateTime dob)
        {
            return (int)((double)new TimeSpan(DateTime.Now.Subtract(dob).Ticks).Days / 365.25);
        }
    }
}