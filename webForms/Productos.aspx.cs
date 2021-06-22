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
        void PopulateGridview()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(cnn))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Pan", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvProductos.DataSource = dtbl;
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
        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                    using (SqlConnection sqlCon = new SqlConnection(cnn))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Pan VALUES (@IDPan,@NombrePan, @DescripcionPan,@PrecioPan,@DistribuidorPan)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@IDPan", (gvProductos.FooterRow.FindControl("txtIDPanFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@NombrePan", (gvProductos.FooterRow.FindControl("txtNombrePanFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@DescripcionPan", (gvProductos.FooterRow.FindControl("txtDescripcionPanFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@PrecioPan", (gvProductos.FooterRow.FindControl("txtPrecioPanFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@DistribuidorPan", (gvProductos.FooterRow.FindControl("txtDistribuidorPanFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
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
        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;
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
                    string query = "UPDATE Pan SET Nombre_Pan=@NombrePan, Descripcion_Pan=@DescripcionPan, Precio_Pan=@PrecioPan, Distribuidor_Pan=@DistribuidorPan WHERE ID_Pan = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
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