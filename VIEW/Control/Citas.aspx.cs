using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL;
using CONTROLLER;
using System.Data;
using System.Data.SqlClient;

namespace VIEW.Control
{
    public partial class Citas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Metodo para agregar las citas con la información de la cita y el usuario seleccionado
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevaCita = new Cita()
                {
                    id_medico = Convert.ToInt32(Session["idUsuario"].ToString()), //La id del medico es el de la sesion
                    idUsuario = Convert.ToInt32(ddlUsuarios.SelectedValue), //La id del usuario es la que está seleccionada en la ddl
                    fecha = Convert.ToDateTime(txtDia.Text),
                    hora = TimeSpan.Parse(txtHora.Text), //El formato de la hora es TimeSpan
                    activo = true,
                    observaciones="Sin Observaciones" //Es el valor por defecto de las observaciones de la cita
                };

                CitaControlador.InsertarCita(nuevaCita);
                mensaje.Visible = true;
            }
            catch (Exception ex )
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
            }
        }

        //Metodo para buscar las citas mediante los criterios de los textbox
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

                var resultado = CitaControlador.BuscarCitaCriterios(txtCriterios.Text, estado);

                gvCitas.DataSource = resultado;
                gvCitas.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
            }
        }

        protected void ImgBtnEliminar_Command(object sender, CommandEventArgs e)
        {
            var idCita = Convert.ToInt32(e.CommandArgument);

            CitaModel.CambiarEstadoCita(idCita);
            Page_Load(null, null);
        }

        //Comando para modificar
        protected void ImgBtnModificar_Command(object sender, CommandEventArgs e)
        {
            btnAgregar.Enabled = false;
            txtDia.Enabled = false;
            txtHora.Enabled = false;
            ddlUsuarios.Enabled = false;
            pnlEditar.Visible = true;
            
            GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent;
            gvCitas.SelectedIndex = row.RowIndex;
            txtIdCita.Text = row.Cells[0].Text;
            txtDiaEdit.Text = row.Cells[2].Text;
            txtHoraEdit.Text = row.Cells[3].Text;
            txtObservacion.Text = row.Cells[4].Text;
        }

        //Metodo para actualizar la información para los usuarios
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string CadenaConexion = "Data source=localhost;initial catalog=Proyecto;integrated Security=True";
                SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
                SqlCommand cmd = new SqlCommand();
                //El comando es para actualizar los datos
                cmd.CommandText = "UPDATE Cita SET fecha=@fecha, hora=@hora, observaciones=@observaciones WHERE idCita=@idCita";
                cmd.Parameters.Add("@idCita", SqlDbType.Int).Value = txtIdCita.Text;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = Convert.ToDateTime(txtDiaEdit.Text); //Se convierte el formato de fecha
                cmd.Parameters.Add("@hora", SqlDbType.Time).Value = TimeSpan.Parse(txtHoraEdit.Text); //TimeSpan es el formato de la hora
                cmd.Parameters.Add("@observaciones", SqlDbType.Text).Value = txtObservacion.Text;
                cmd.Connection = conexionSQL;
                conexionSQL.Open(); //Se abre la conexión
                cmd.ExecuteNonQuery(); //Se ejecuta el comando

                pnlEditar.Visible = false;
                btnAgregar.Enabled = true;
                txtDia.Enabled = true;
                txtHora.Enabled = true;
                ddlUsuarios.Enabled = true;
                var resultado = CitaControlador.BuscarCitaCriterios(string.Empty, true); //Con esto actualiza el Gv

                gvCitas.DataSource = resultado;
                gvCitas.DataBind(); //Llena el GV con la información
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