using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using MODEL;
using CONTROLLER;

namespace VIEW.Control
{
    public partial class Platillos : System.Web.UI.Page
    {
        ///<param name=" CadenaConexion">string Cadena de conexion para la base de datos</param>
        string CadenaConexion = "Data Source=SQL5053.site4now.net;Initial Catalog=db_a75d97_proyecto;User Id=db_a75d97_proyecto_admin;Password=nutriw2021";
        /// <summary>
        /// Carga de la página
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Metodo click, agregar platillo a la base de datos
        /// 
        /// Inserta la imagen del platillo y todos sus datos dentro de la base de datos
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos de la imagen
                int tamanio = fuploadImagen.PostedFile.ContentLength;
                byte[] imagenOriginal = new byte[tamanio];
                fuploadImagen.PostedFile.InputStream.Read(imagenOriginal, 0, tamanio);
                Bitmap imagenOriginalBinaria = new Bitmap(fuploadImagen.PostedFile.InputStream);
                //Crear Thumbnail
                System.Drawing.Image imgThumbnail;
                int tamanioThumbnail = 200;
                imgThumbnail = redimencionarImagen(imagenOriginalBinaria, tamanioThumbnail);
                byte[] bImagenThumbnail = new byte[tamanioThumbnail];
                ImageConverter Convertidor = new ImageConverter();
                bImagenThumbnail = (byte[])Convertidor.ConvertTo(imgThumbnail, typeof(byte[]));

                //Insertar en la bd
                SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Platillo(imagen, nombre, descripcion) VALUES(@imagen, @nombre, @descripcion)";
                cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = bImagenThumbnail;
                cmd.Parameters.Add("@nombre", SqlDbType.Text).Value = txtNombre.Text;
                cmd.Parameters.Add("@descripcion", SqlDbType.Text).Value = txtDescripcion.Text;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexionSQL;
                conexionSQL.Open();
                cmd.ExecuteNonQuery();

                string imagenDataUrl64 = "data:image/jpg;base64," + Convert.ToBase64String(bImagenThumbnail);
                imgPreview.ImageUrl = imagenDataUrl64;

                var resultado = PlatillosControlador.BuscarPlatilloCriterios(txtCriterios.Text, true);

                gvPlatillos.DataSource = resultado;
                gvPlatillos.DataBind();
                txtNombre.Text = "";
                txtDescripcion.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
                string javaScript = "OcultarMensajeError();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }
        }

        /// <summary>
        /// Metodo para redimencionar una imagen
        /// 
        /// La imagen que se insertara en la base de datos debe tener un tamaño regulado
        /// </summary>
        /// <param name="imagenOriginal">Alto de la imagen original</param>
        /// <param name="Alto">Alto de la imagen</param>
        /// <returns></returns>
        public System.Drawing.Image redimencionarImagen(System.Drawing.Image imagenOriginal, int Alto)
        {
            var radio = (double)Alto / imagenOriginal.Height;
            var nuevoAncho = (int)(imagenOriginal.Width * radio);
            var nuevoAlto = (int)(imagenOriginal.Height * radio);
            var nuevaImagenRedimencionada = new Bitmap(nuevoAncho, nuevoAlto);
            var g = Graphics.FromImage(nuevaImagenRedimencionada);
            g.DrawImage(imagenOriginal, 0, 0, nuevoAncho, nuevoAlto);
            return nuevaImagenRedimencionada;

        }

        /// <summary>
        /// Metodo click para buscar usuarios
        /// 
        /// Al hacer click en el boton buscar, toma los datos de los criterios y busca coincidencia
        /// de los platillo atraves del controlador conectado al modelo, si un error ocurre, se muestra
        /// el mensaje de error correspondiente atraves del try-catch
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        /// <param name="estado">bool Comprueba el estado de la consulta</param>
        /// <param name="resultado">var resultado el resultado de la consulta</param>
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

                var resultado = PlatillosControlador.BuscarPlatilloCriterios(txtCriterios.Text, estado);

                gvPlatillos.DataSource = resultado;
                gvPlatillos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
            }
        }

        /// <summary>
        /// Metodo comando, ejecuta el comando para eliminar algun platillo seleccionado
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void ImgBtnEliminar_Command(object sender, CommandEventArgs e)
        {
            var idPlatillo = Convert.ToInt32(e.CommandArgument);

            PlatillosControlador.CambiarEstadoPlatillo(idPlatillo);
            Page_Load(null, null);
        }

        /// <summary>
        /// Metodo comando, Se ejecuta el comando para para abrir el panel de modificación
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void ImgBtnModificar_Command(object sender, CommandEventArgs e)
        {
            pnlEditar.Visible = true;
            GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent;
            gvPlatillos.SelectedIndex = row.RowIndex;
            txtId.Text = row.Cells[0].Text;
            txtNombreEdit.Text = row.Cells[1].Text;
            txtDescripcionEdit.Text = row.Cells[2].Text;
        }

        /// <summary>
        /// Metodo click, actualiza en la base de datos la inforación del platillo
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Argumento de evento</param>
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos de la imagen
                int tamanio = fuploadImagenEdit.PostedFile.ContentLength;
                byte[] imagenOriginal = new byte[tamanio];
                fuploadImagenEdit.PostedFile.InputStream.Read(imagenOriginal, 0, tamanio);
                Bitmap imagenOriginalBinaria = new Bitmap(fuploadImagenEdit.PostedFile.InputStream);
                //Crear Thumbnail
                System.Drawing.Image imgThumbnail;
                int tamanioThumbnail = 200;
                imgThumbnail = redimencionarImagen(imagenOriginalBinaria, tamanioThumbnail);
                byte[] bImagenThumbnail = new byte[tamanioThumbnail];
                ImageConverter Convertidor = new ImageConverter();
                bImagenThumbnail = (byte[])Convertidor.ConvertTo(imgThumbnail, typeof(byte[]));

                //Insertar en la bd
                SqlConnection conexionSQL = new SqlConnection(CadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Platillo SET nombre=@nombre, descripcion=@descripcion, " +
                                  "imagen=@imagen WHERE idPlatillo=@idPlatillo";
                cmd.Parameters.Add("@idPlatillo", SqlDbType.Int).Value = txtId.Text;
                cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = bImagenThumbnail;
                cmd.Parameters.Add("@nombre", SqlDbType.Text).Value = txtNombreEdit.Text;
                cmd.Parameters.Add("@descripcion", SqlDbType.Text).Value = txtDescripcionEdit.Text;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexionSQL;
                conexionSQL.Open();
                cmd.ExecuteNonQuery();

                string imagenDataUrl64 = "data:image/jpg;base64," + Convert.ToBase64String(bImagenThumbnail);
                imgPreview.ImageUrl = imagenDataUrl64;

                pnlEditar.Visible = false;
                var resultado = PlatillosControlador.BuscarPlatilloCriterios(txtCriterios.Text, true);

                gvPlatillos.DataSource = resultado;
                gvPlatillos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                mensajeError.Visible = true;
                string javaScript = "OcultarMensajeError();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
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
    }
}