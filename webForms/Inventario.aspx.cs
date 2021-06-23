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
    public partial class Inventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenadoDropDown();
                PopulateGridview();
            }
        }
        /*basicamente esta funcion es para poner en la tabla toda la información*/
        void PopulateGridview()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(cnn))
            {
                sqlCon.Open();
                /*El SqlDataAdapter, actúa como puente entre un DataSet y SQL Server para recuperar
                 * y guardar datos y proporciona este puente mediante la asignación de Fill,*/
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Inventario_Existencias.ID_Pan, Pan.Nombre_Pan, Inventario_Existencias.Cantidad_Existencias, Pan.Precio_Pan FROM Inventario_Existencias JOIN Pan ON Inventario_Existencias.ID_Pan = Pan.ID_Pan", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                /*DataSource hace referencia a la fuente de datos,*/
                gvInventario.DataSource = dtbl;
                /*lo que hace este metodo es enlazar los datos del origen de datos al control*/
                gvInventario.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvInventario.DataSource = dtbl;
                gvInventario.DataBind();
                gvInventario.Rows[0].Cells.Clear();
                gvInventario.Rows[0].Cells.Add(new TableCell());
                gvInventario.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvInventario.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvInventario.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        public void LlenadoDropDown()
        {
            dropDownProductosI.DataSource = DropDownConexion("SELECT * FROM Pan");
            dropDownProductosI.DataTextField = "Nombre_Pan";
            dropDownProductosI.DataValueField = "ID_Pan";
            dropDownProductosI.DataBind();
            dropDownProductosI.Items.Insert(0, new ListItem("[Selecccionar]", "0"));
        }
        public DataSet DropDownConexion(string query)
        {
            DataSet ds = new DataSet(); ;
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataAdapter da = new SqlDataAdapter(comando);

                    da.Fill(ds);
                    conexion.Close();
                    lblErrorMessage.Text = "";

                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            return ds;
        }

        protected void AgregarInventario(object sender, EventArgs e)
        {
            try
            {
                int cantidadPanIn;


                cantidadPanIn = Int32.Parse(txtCantidadI.Text);


                string cad = "INSERT INTO Inventario_Existencias VALUES (" + cantidadPanIn + ",1 ," + dropDownProductosI.SelectedValue + ")";
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    SqlCommand comando = new SqlCommand(cad, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    PopulateGridview();
                    ClientScript.RegisterStartupScript(GetType(), "mostrar", "ProductoAgregadoI();", true);
                    lblErrorMessage.Text = "";
                    lblSuccessMessage.Text = "";
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
            gvInventario.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }
        /*Este evento se genera cuando cancelamos la actualización de un registro, 
         * lo que significa que lo usamos cuando estamos en modo de edición de un GridView 
         * y queremos que GridView vuelva al modo de visualización sin ninguna actualización.*/
        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvInventario.EditIndex = -1;
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
                    string query = "UPDATE Inventario_Existencias SET Cantidad_Existencias=@CantidadExistencias WHERE ID_Inventario=1 AND ID_Pan = @idPan";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    /*Se usa para la actualizacion de los datos que ya esten insetados, obtiene los datos que esten el las seldas para modificar*/
                    sqlCmd.Parameters.AddWithValue("@CantidadExistencias", double.Parse((gvInventario.Rows[e.RowIndex].FindControl("txtCantidadExistencia") as TextBox).Text.Trim()));
                    
                    sqlCmd.Parameters.AddWithValue("@idPan", Convert.ToInt32(gvInventario.DataKeys[e.RowIndex].Value.ToString()));

                    sqlCmd.ExecuteNonQuery();
                    gvInventario.EditIndex = -1;
                    PopulateGridview();

                    lblSuccessMessage.Text = "Registro actualizado";
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
                    string query = "DELETE FROM Inventario_Existencias WHERE ID_Inventario=1 AND ID_Pan = @idPan";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    /*obtiene el parametro que tenga la llave primaria para borrar el registro con ese parametro*/
                    sqlCmd.Parameters.AddWithValue("@idPan", Convert.ToInt32(gvInventario.DataKeys[e.RowIndex].Value.ToString()));
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