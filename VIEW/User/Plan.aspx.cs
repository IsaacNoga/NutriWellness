using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace VIEW.User
{
    public partial class Plan : System.Web.UI.Page
    {
        //Al cargar la pagina, se consulta a la base de datos mediante el la información del plan del paciente
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string CadenaConexion = "Data source=localhost;initial catalog=Proyecto;integrated Security=True";
                SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM PlanNutri Where idUsuario=@idUsuario";
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = Convert.ToInt32(Session["idUsuario"].ToString());

                cmd.Connection = conexionSQL;
                conexionSQL.Open();
                DataTable nueva = new DataTable();
                nueva.Load(cmd.ExecuteReader());

                gvPlan.DataSource = nueva;
                gvPlan.DataBind();
                conexionSQL.Close();
                var idUser= Convert.ToInt32(Session["idUsuario"].ToString()); //La variable de sesion
                SqlCommand comando = new SqlCommand("SELECT * FROM DIETAINFO WHERE idInfo=@idUsuario", conexionSQL);
                comando.Parameters.AddWithValue("@idUsuario", idUser);
                conexionSQL.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    txtPeso.Text = reader["peso"].ToString();
                    txtAltura.Text = reader["altura"].ToString();
                    txtIMCI.Text = reader["imcInicial"].ToString();
                    txtIMCA.Text = reader["imcActual"].ToString();
                    txtResultado.Text = reader["resultado"].ToString();
                    txtNaf.Text = reader["naf"].ToString();
                }
                conexionSQL.Close();
                SqlCommand comando2 = new SqlCommand("SELECT * FROM USUARIO WHERE idUsuario=@idUsuario2", conexionSQL);
                comando2.Parameters.AddWithValue("@idUsuario2", idUser);
                conexionSQL.Open();
                SqlDataReader reader2 = comando2.ExecuteReader();
                if (reader2.Read())
                {
                    lblNombre.Text = "Paciente: " + reader2["nombre"].ToString() + " " + reader2["aPaterno"].ToString() + " " + reader2["aMaterno"].ToString();
                }
                conexionSQL.Close();
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
    }
}