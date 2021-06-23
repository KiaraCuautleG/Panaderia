using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Panaderia.webForms
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }
        }
        /*Se llama así porque lo encontre en otro ejemplo y se me olvido cambiarle el nombre xD 
         pero basicamente esta funcion es para poner en la tabla toda la información*/
        void PopulateGridview()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(cnn))
            {
                sqlCon.Open();
                /*El SqlDataAdapter, actúa como puente entre un DataSet y SQL Server para recuperar
                 * y guardar datos y proporciona este puente mediante la asignación de Fill,*/
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Pan", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                /*DataSource hace referencia a la fuente de datos,*/
                gvProductos.DataSource = dtbl;
                /*lo que hace este metodo es enlazar los datos del origen de datos al control*/
                gvProductos.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvProductos.DataSource = dtbl;
                gvProductos.DataBind();
                gvProductos.Rows[0].Cells.Clear();
                gvProductos.Rows[0].Cells.Add(new TableCell());
                gvProductos.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvProductos.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvProductos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        /*igual se llama así porque se me olvido cambiar el nombre
         pero esta funcion nos va ayudar a añadir más regristros*/
        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                /*si se a elegido el boton addnew se podrán ingresar los datos entroducidos al final*/
                if (e.CommandName.Equals("AddNew"))
                {
                    string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                    using (SqlConnection sqlCon = new SqlConnection(cnn))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Pan VALUES (@IDPan,@NombrePan, @DescripcionPan,@PrecioPan,@DistribuidorPan)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        /*recogemos los parametros que se van a introducir en la sentencia sql, estos parametros se obtienen desde las celdas de la tabla que a su mismo actua 
                         como un txtBox*/
                        sqlCmd.Parameters.AddWithValue("@IDPan", (gvProductos.FooterRow.FindControl("txtIDPanFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@NombrePan", (gvProductos.FooterRow.FindControl("txtNombrePanFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@DescripcionPan", (gvProductos.FooterRow.FindControl("txtDescripcionPanFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@PrecioPan", (gvProductos.FooterRow.FindControl("txtPrecioPanFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@DistribuidorPan", (gvProductos.FooterRow.FindControl("txtDistribuidorPanFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();

                        /*Se manda a llamar la tabla, es decir se manda a llamar esta funcion para actualizarse*/
                        PopulateGridview();
                        lblSuccessMessage.Text = "Nuevo pan agregado";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        /*
         Este evento GridView se usa para cambiar el modo GridView. Este evento se genera cuando 
        se hace clic en el botón de edición de una fila, pero antes de que GridView entre en el modo 
        de edición.*/
        
        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        /*Este evento se genera cuando cancelamos la actualización de un registro, 
         * lo que significa que lo usamos cuando estamos en modo de edición de un GridView 
         * y queremos que GridView vuelva al modo de visualización sin ninguna actualización.*/
        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;
            PopulateGridview();
        }

        /*este metodo nos permite actualizar los datos de las correspondientes filas*/
        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try

            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(cnn))
                {
                    sqlCon.Open();
                    string query = "UPDATE Pan SET Nombre_Pan=@NombrePan, Descripcion_Pan=@DescripcionPan, Precio_Pan=@PrecioPan, Distribuidor_Pan=@DistribuidorPan WHERE ID_Pan = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    /*Se usa para la actualizacion de los datos que ya esten insetados, obtiene los datos que esten el las seldas para modificar*/
                    sqlCmd.Parameters.AddWithValue("@DescripcionPan", (gvProductos.Rows[e.RowIndex].FindControl("txtDescripcionPan") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@NombrePan", (gvProductos.Rows[e.RowIndex].FindControl("txtNombrePan") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@PrecioPan", double.Parse((gvProductos.Rows[e.RowIndex].FindControl("txtPrecioPan") as TextBox).Text.Trim()));
                    sqlCmd.Parameters.AddWithValue("@DistribuidorPan", (gvProductos.Rows[e.RowIndex].FindControl("txtDistribuidorPan") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvProductos.DataKeys[e.RowIndex].Value.ToString()));
                    
                    sqlCmd.ExecuteNonQuery();
                    gvProductos.EditIndex = -1;
                    PopulateGridview();

                    lblSuccessMessage.Text = "Registro de pan actualizado";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }


        }

        /* se usa para borrar alguna fila que ya no se quiera*/
        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(cnn))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Pan WHERE ID_Pan = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    /*obtiene el parametro que tenga la llave primaria para borrar el registro con ese parametro*/
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvProductos.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Registro eliminado";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}