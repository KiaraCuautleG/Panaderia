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
    public partial class ConsultarVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewDetalle_Ventas();
                GridVentas();

            }
        }
        public void GridVentas()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(cnn))
            {
                sqlCon.Open();

                /*El SqlDataAdapter, actúa como puente entre un DataSet y SQL Server para recuperar
                 * y guardar datos y proporciona este puente mediante la asignación de Fill,*/
                /*SE Usa COnvert para que solo nos devuelva la fecha de la venta*/
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT ID_Venta, Convert(VARCHAR(10), Fecha_Venta) Fecha_Venta, Total_Venta FROM Venta ", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                /*DataSource hace referencia a la fuente de datos,*/
                GridViewVentas.DataSource = dtbl;
                /*lo que hace este metodo es enlazar los datos del origen de datos al control*/
                GridViewVentas.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
               GridViewVentas.DataSource = dtbl;
               GridViewVentas.DataBind();
               GridViewVentas.Rows[0].Cells.Clear();
               GridViewVentas.Rows[0].Cells.Add(new TableCell());
               GridViewVentas.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
               GridViewVentas.Rows[0].Cells[0].Text = "No Data Found ..!";
               GridViewVentas.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        public void GridViewDetalle_Ventas()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(cnn))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Detalle_Venta.ID_Venta, Detalle_Venta.ID_Pan,  Pan.Nombre_Pan, Pan.Precio_Pan, Detalle_Venta.Cantidad_Detalle, Detalle_Venta.Subtotal_Detalle FROM Detalle_Venta  INNER JOIN Pan  ON Detalle_Venta.ID_Pan = Pan.ID_Pan ", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                DetalleVenta.DataSource = dtbl;
                DetalleVenta.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                DetalleVenta.DataSource = dtbl;
                DetalleVenta.DataBind();
                DetalleVenta.Rows[0].Cells.Clear();
                DetalleVenta.Rows[0].Cells.Add(new TableCell());
                DetalleVenta.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                DetalleVenta.Rows[0].Cells[0].Text = "No Data Found ..!";
                DetalleVenta.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
    }
}