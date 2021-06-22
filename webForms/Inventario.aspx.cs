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
        void PopulateGridview()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(cnn))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Inventario_Existencias.ID_Pan, Pan.Nombre_Pan, Inventario_Existencias.Cantidad_Existencias, Pan.Precio_Pan FROM Inventario_Existencias JOIN Pan ON Inventario_Existencias.ID_Pan = Pan.ID_Pan", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvInventario.DataSource = dtbl;
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

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvInventario.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvInventario.EditIndex = -1;
            PopulateGridview();
        }

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