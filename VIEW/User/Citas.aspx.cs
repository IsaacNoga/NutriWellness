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



namespace VIEW.User
{
    public partial class Citas : System.Web.UI.Page
    {
        //Al cargar la pagina, se muestra la información del historial de las citas del usuario
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string CadenaConexion = "Data source=localhost;initial catalog=Proyecto;integrated Security=True";
                SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Cita Where idUsuario=@idUsuario";
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = Convert.ToInt32(Session["idUsuario"].ToString());

                cmd.Connection = conexionSQL;
                conexionSQL.Open();
                DataTable nueva = new DataTable();
                nueva.Load(cmd.ExecuteReader());

                gvCitas.DataSource = nueva;
                gvCitas.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}