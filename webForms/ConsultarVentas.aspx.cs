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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Venta", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                GridViewVentas.DataSource = dtbl;
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