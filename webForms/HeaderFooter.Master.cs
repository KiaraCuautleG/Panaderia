using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Panaderia.webForms
{
    public partial class HeaderFooter : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnk_Ventas(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }

        protected void lnk_VerVentas(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarVentas.aspx");
        }

        protected void lnk_Inventario(object sender, EventArgs e)
        {
            Response.Redirect("Inventario.aspx");
        }

        protected void lnk_Productos(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }

        protected void lnk_Salir(object sender, EventArgs e)
        {
            Response.Redirect("InicioSesion.aspx");
        }
    }
}