using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MODEL;
using CONTROLLER;

namespace VIEW.Control
{
    public partial class DietaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Metodo para editar la información de la dieta del usuario y traer la información a los textbox
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var idUsuario = ddlUsuarios.SelectedValue;
            string CadenaConexion = "Data source=localhost;initial catalog=Proyecto;integrated Security=True";
            SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
            SqlCommand comando = new SqlCommand("SELECT * FROM DIETAINFO WHERE idInfo=@idUsuario", conexionSQL);
            comando.Parameters.AddWithValue("@idUsuario", idUsuario);
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
            comando2.Parameters.AddWithValue("@idUsuario2", idUsuario);
            conexionSQL.Open();
            SqlDataReader reader2 = comando2.ExecuteReader();
            if (reader2.Read())
            {
                lblNombre.Text ="Paciente: " + reader2["nombre"].ToString() +" "+ reader2["aPaterno"].ToString() + " " + reader2["aMaterno"].ToString();
            }
            conexionSQL.Close();
            SqlCommand comando3 = new SqlCommand("SELECT * FROM PlanNutri WHERE idUsuario=@idUsuario3", conexionSQL);
            comando3.Parameters.AddWithValue("@idUsuario3", idUsuario);
            conexionSQL.Open();
            SqlDataReader reader3 = comando3.ExecuteReader();
            if (reader3.Read())
            {
                txtDesayuno.Text = reader3["Desayuno"].ToString();
                txtComida.Text = reader3["Comida"].ToString();
                txtCena.Text = reader3["Cena"].ToString();
                txtColaciones.Text = reader3["Colaciones"].ToString();

            }
            conexionSQL.Close();
            pnlSeleccionar.Enabled = false;
            pnlDieta.Visible = true;
            pnlPlan.Visible = true;
            if(txtIMCI.Text=="Sin definir")
            {
                txtIMCI.Enabled = true;
            }
            else
            {
                txtIMCI.Enabled = false;
            }
        }

        //Al dar click en guardar, guarda la información de la dieta
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var ID = ddlUsuarios.SelectedValue;
            try
            {
                if (String.IsNullOrEmpty(txtAltura.Text) || String.IsNullOrEmpty(txtIMCA.Text) || String.IsNullOrEmpty(txtIMCI.Text) || 
                    String.IsNullOrEmpty(txtNaf.Text) || String.IsNullOrEmpty(txtPeso.Text) || String.IsNullOrEmpty(txtResultado.Text)||
                    String.IsNullOrEmpty(txtDesayuno.Text) || String.IsNullOrEmpty(txtComida.Text) || String.IsNullOrEmpty(txtCena.Text) || 
                    String.IsNullOrEmpty(txtColaciones.Text))
                {

                    lblError.Text = "Error: Todos los campos deben ser llenados";  //Texto del error si algún dato está vacio
                    mensajeError.Visible = true;

                }
                else
                {
                    string CadenaConexion = "Data source=localhost;initial catalog=Proyecto;integrated Security=True";
                    SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE DietaInfo SET idUsuario=@idUsuario, imcInicial=@imcInicial, imcActual=@imcActual, " +
                                      "peso=@peso, altura=@altura, naf=@naf, resultado=@resultado WHERE idInfo=@idInfo";
                    cmd.Parameters.Add("@idInfo", SqlDbType.Int).Value = ID;
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = ID;
                    cmd.Parameters.Add("@imcInicial", SqlDbType.VarChar).Value = txtIMCI.Text;
                    cmd.Parameters.Add("@imcActual", SqlDbType.VarChar).Value = txtIMCA.Text;
                    cmd.Parameters.Add("@peso", SqlDbType.VarChar).Value = txtPeso.Text;
                    cmd.Parameters.Add("@altura", SqlDbType.VarChar).Value = txtAltura.Text;
                    cmd.Parameters.Add("@naf", SqlDbType.VarChar).Value = txtNaf.Text;
                    cmd.Parameters.Add("@resultado", SqlDbType.VarChar).Value = txtResultado.Text;
                    cmd.Connection = conexionSQL;
                    conexionSQL.Open();
                    cmd.ExecuteNonQuery();
                    conexionSQL.Close();


                    SqlConnection conexionSQL2 = new SqlConnection(CadenaConexion);
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "UPDATE PlanNutri SET idUsuario=@idUsuario, Desayuno=@Desayuno, Comida=@Comida, " +
                                       "Cena=@Cena, Colaciones=@Colaciones WHERE idPlan=@idPlan";
                    cmd2.Parameters.Add("@idPlan", SqlDbType.Int).Value = ID;
                    cmd2.Parameters.Add("@idUsuario", SqlDbType.Int).Value = ID;
                    cmd2.Parameters.Add("@Desayuno", SqlDbType.VarChar).Value = txtDesayuno.Text;
                    cmd2.Parameters.Add("@Comida", SqlDbType.VarChar).Value = txtComida.Text;
                    cmd2.Parameters.Add("@Cena", SqlDbType.VarChar).Value = txtCena.Text;
                    cmd2.Parameters.Add("@Colaciones", SqlDbType.VarChar).Value = txtColaciones.Text;
                    cmd2.Connection = conexionSQL2;
                    conexionSQL2.Open();
                    cmd2.ExecuteNonQuery();
                    conexionSQL2.Close();

                    pnlSeleccionar.Enabled = true;
                    pnlDieta.Visible = false;
                    pnlPlan.Visible = false;
                    mensaje.Visible = true;
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
            mensaje.Visible = false;
        }
    }
}