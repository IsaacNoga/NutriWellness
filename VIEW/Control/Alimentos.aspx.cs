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
    public partial class Alimentos : System.Web.UI.Page
    {
        /// <summary>
        /// Carga de la página 
        /// 
        /// Al cargar la pagina, se llena el GridView con la información de los usuarios
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var resultado = AlimentosControlador.BuscarAlimentoCriterios(txtCriterios.Text);

            gvAlimentos.DataSource = resultado;
            gvAlimentos.DataBind();
        }

        ///<param name=" CadenaConexion">string Cadena de conexion para la base de datos</param>
        string CadenaConexion = "Data Source=SQL5053.site4now.net;Initial Catalog=db_a75d97_proyecto;User Id=db_a75d97_proyecto_admin;Password=nutriw2021";
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
                var resultado = AlimentosControlador.BuscarAlimentoCriterios(txtCriterios.Text);
                //Se utilizan la iformación esctrita en el textbox para buscar los mensajes
                gvAlimentos.DataSource = resultado;
                gvAlimentos.DataBind(); //Llena el GV con la información
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true; //Se muestra el error
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

        //
        /// <summary>
        /// Metodo comando, Se ejecuta el comando para abrir el manel de modificación.
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void ImgBtnModificar_Command(object sender, CommandEventArgs e)
        {
            pnlEditar.Visible = true;
            pnlAlimentos.Enabled = false;
            GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent;
            gvAlimentos.SelectedIndex = row.RowIndex;
            TextBox0.Text = row.Cells[0].Text;
            TextBox1.Text = row.Cells[1].Text;
            TextBox2.Text = row.Cells[2].Text;
            TextBox3.Text = row.Cells[3].Text;
            TextBox4.Text = row.Cells[4].Text;
            TextBox5.Text = row.Cells[5].Text;
            TextBox6.Text = row.Cells[6].Text;
            TextBox7.Text = row.Cells[7].Text;
            TextBox8.Text = row.Cells[8].Text;
            TextBox9.Text = row.Cells[9].Text;
            TextBox10.Text = row.Cells[10].Text;
            TextBox11.Text = row.Cells[11].Text;
            TextBox12.Text = row.Cells[12].Text;
            TextBox13.Text = row.Cells[13].Text;
            TextBox14.Text = row.Cells[14].Text;
            TextBox15.Text = row.Cells[15].Text;
            TextBox16.Text = row.Cells[16].Text;
        }

        /// <summary>
        /// Metodo click, Mediante el controlador, se agrega un alimento nuevo a la base de datos
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        /// <param name="Alimento">var Guarda los datos de la dieta a agregar</param>
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var Alimento = new Alimento()
                {
                    nombre = txtNombre.Text,
                    potasio = txtPotasio.Text,
                    hierro = txtHierro.Text,
                    acidoFolico = txtAcidoFolico.Text,
                    vitmaminaA = txtVitaminaA.Text,
                    fibra = txtFibra.Text,
                    pesoBruto = txtPesoBruto.Text,
                    pesoNeto = txtPesoNeto.Text,
                    energia = txtEnergia.Text,
                    protenia = txtProteina.Text,
                    lipidos = txtLipidos.Text,
                    hidratosDC = txtHidratos.Text,
                    cargaGlic = txtCargaGlic.Text,
                    indiceGlic = txtIndiceGlic.Text,
                    unidad = txtUnidad.Text,
                    cantidadSu = txtCantidadSu.Text
                };

                AlimentosControlador.InsertarAlimento(Alimento);
                pnlAgregar.Visible = false;
                pnlAlimentos.Enabled = true;

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
            }
        }

        /// <summary>
        /// Metodo click, al dar click en agregar, modifica los paneles
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void btnAgregarA_Click(object sender, EventArgs e)
        {
            pnlAlimentos.Enabled = false;
            pnlAgregar.Visible = true;
        }

        /// <summary>
        /// Metodo click, guarda los datos de los alimentos al dar click en el boton
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text) || string.IsNullOrEmpty(TextBox3.Text) ||
                    string.IsNullOrEmpty(TextBox4.Text) || string.IsNullOrEmpty(TextBox5.Text) || string.IsNullOrEmpty(TextBox6.Text) ||
                    string.IsNullOrEmpty(TextBox7.Text) || string.IsNullOrEmpty(TextBox8.Text) || string.IsNullOrEmpty(TextBox9.Text) ||
                    string.IsNullOrEmpty(TextBox10.Text) || string.IsNullOrEmpty(TextBox11.Text) || string.IsNullOrEmpty(TextBox12.Text) ||
                    string.IsNullOrEmpty(TextBox13.Text) || string.IsNullOrEmpty(TextBox14.Text) || string.IsNullOrEmpty(TextBox15.Text) ||
                    string.IsNullOrEmpty(TextBox16.Text))
                {
                    lblError.Text = "Error: No se aceptan campos vacios.";  //Texto del error si algún dato está vacio
                    mensajeError.Visible = true;
                }
                else
                {
                    //string CadenaConexion = "Data source=localhost;initial catalog=Proyecto;integrated Security=True";
                    SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE Alimento SET nombre=@nombre, potasio=@potasio, hierro=@hierro, acidoFolico=@acidoFolico, vitmaminaA=@vitmaminaA," +
                        "fibra=@fibra, pesoBruto=@pesoBruto, pesoNeto=@pesoNeto, energia=@energia, protenia=@protenia, lipidos=@lipidos, hidratosDC=@hidratosDC," +
                        "cargaGlic=@cargaGlic, indiceGlic=@indiceGlic, unidad=@unidad, cantidadSu=@cantidadSu WHERE idAlimento=@idAlimento";

                    cmd.Parameters.Add("@idAlimento", SqlDbType.Int).Value = TextBox0.Text;
                    cmd.Parameters.Add("@nombre", SqlDbType.Text).Value = TextBox1.Text;
                    cmd.Parameters.Add("@potasio", SqlDbType.Text).Value = TextBox2.Text;
                    cmd.Parameters.Add("@hierro", SqlDbType.Text).Value = TextBox3.Text;
                    cmd.Parameters.Add("@acidoFolico", SqlDbType.Text).Value = TextBox4.Text;
                    cmd.Parameters.Add("@vitmaminaA", SqlDbType.Text).Value = TextBox5.Text;

                    cmd.Parameters.Add("@fibra", SqlDbType.Text).Value = TextBox6.Text;
                    cmd.Parameters.Add("@pesoBruto", SqlDbType.Text).Value = TextBox7.Text;
                    cmd.Parameters.Add("@pesoNeto", SqlDbType.Text).Value = TextBox8.Text;
                    cmd.Parameters.Add("@energia", SqlDbType.Text).Value = TextBox9.Text;
                    cmd.Parameters.Add("@protenia", SqlDbType.Text).Value = TextBox10.Text;

                    cmd.Parameters.Add("@lipidos", SqlDbType.Text).Value = TextBox11.Text;
                    cmd.Parameters.Add("@hidratosDC", SqlDbType.Text).Value = TextBox12.Text;
                    cmd.Parameters.Add("@cargaGlic", SqlDbType.Text).Value = TextBox13.Text;
                    cmd.Parameters.Add("@indiceGlic", SqlDbType.Text).Value = TextBox14.Text;
                    cmd.Parameters.Add("@unidad", SqlDbType.Text).Value = TextBox15.Text;
                    cmd.Parameters.Add("@cantidadSu", SqlDbType.Text).Value = TextBox16.Text;
                    cmd.Connection = conexionSQL;
                    conexionSQL.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/Control/Alimentos.aspx");
                }


                pnlEditar.Visible = false;
                pnlAlimentos.Enabled = true;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
            }
        }

        protected void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            pnlAgregar.Visible = false;
            pnlAlimentos.Enabled = true;
        }
    }
}