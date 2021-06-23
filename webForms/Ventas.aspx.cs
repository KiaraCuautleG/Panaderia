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
    public partial class Ventas : System.Web.UI.Page
    {
        static int idVentas= 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenadoDropDown();
                ObtenerIdVenta();
                txtCantidad.Enabled = false;
                DropDownList1.Enabled = false;
                btnAgregar.Enabled = false;
                btnEnviar.Enabled = false;

            }
        }
        public void ObtenerIdVenta()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                string query = "SELECT TOP 1 [ID_Venta] FROM Venta ORDER BY [ID_Venta] DESC ";
                SqlCommand comando = new SqlCommand(query, conexion);


                double utlimoId = Double.Parse(comando.ExecuteScalar().ToString()) + 1;
                lblIDVenta.Text = utlimoId.ToString();  
                conexion.Close();
            }
        }
        /*-----------------------------------INICIAR VENTA-----------------------------*/
        protected void btnIniciarVenta_Click(object sender, EventArgs e)
        {
            IniciarVenta();
            //ClientScript.RegisterStartupScript(GetType(), "mostrar", "diHola();", true);
            
        }
        public void IniciarVenta()
        {
            try
            {
                if(Calendar1.SelectedDate.ToShortDateString() != "01/01/0001")
                {
                    idVentas = Int32.Parse(lblIDVenta.Text);
                    double total = 0;
                    string fecha = Calendar1.SelectedDate.Year.ToString() + "-" + Calendar1.SelectedDate.Month.ToString() + "-" + Calendar1.SelectedDate.Day.ToString();
                    string cad = "INSERT INTO Venta(ID_Venta, Fecha_Venta, Total_Venta, ID_Usuario) VALUES (" + idVentas + ",'" + fecha + "'," + total + ", '1')";
                    string edoVenta = "Venta iniciada";
                    Conexion(cad, edoVenta);

                    txtCantidad.Enabled = true;
                    DropDownList1.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnEnviar.Enabled = true;
                    lblErrorMessage.Text = "";
                }
                else
                {
                    lblErrorMessage.Text = "Seleccione una fecha";
                }
                 
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        /*-----------------------------------AGREGAR VENTA POR PRODUCTO-----------------------------*/
        public void LlenadoDropDown()
        {
            DropDownList1.DataSource = DropDownConexion("SELECT Inventario_Existencias.ID_Pan, Pan.Nombre_Pan FROM Inventario_Existencias JOIN Pan ON Inventario_Existencias.ID_Pan = Pan.ID_Pan");
            DropDownList1.DataTextField = "Nombre_Pan";
            DropDownList1.DataValueField = "ID_Pan";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("[Selecccionar]", "0"));
            
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
        public double LlenadoPrecio()
        {
            double precioPan = 0.0;
            try
            {

                //Obtener precio de pan ---
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    string query = "SELECT Precio_Pan FROM Pan WHERE ID_Pan =" + DropDownList1.SelectedValue;
                    SqlCommand comando = new SqlCommand(query, conexion);

                    /*SqlDataReader myReader = comando.ExecuteReader();*/

                    precioPan = Double.Parse(comando.ExecuteScalar().ToString());
                    conexion.Close();
                }
                //-------------------------------
                lblErrorMessage.Text = "";

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            return precioPan;
        }
        /*Al seleccionar el producto se pondrá su respectivo precio*/
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecio.Text = LlenadoPrecio().ToString();
            lblErrorMessage2.Text = "";
        }
        /*Al agregar productos a la venta por producto se irán restando al inventario*/
        public void RelacionInventario()
        {
            try
            {
                double cantidadExistencias;
                double cantidadFinalExistencia;
                int cantidadPan;
                bool ban = false;
                cantidadPan = Int32.Parse(txtCantidad.Text);
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    //Obtener cantidad de existencias ---
                    string query = "SELECT Cantidad_Existencias FROM Inventario_Existencias WHERE ID_Inventario=1 AND ID_Pan =" + DropDownList1.SelectedValue;
                    SqlCommand comando = new SqlCommand(query, conexion);

                    cantidadExistencias = double.Parse(comando.ExecuteScalar().ToString());
                    //Reducir las existencias 
                    if(cantidadExistencias> cantidadPan)
                    {
                        

                        double subtotal;
                        int idPan;

                        subtotal = cantidadPan * LlenadoPrecio();

                        string cad = "INSERT INTO Detalle_Venta VALUES (" + idVentas + "," + cantidadPan + "," + subtotal + "," + DropDownList1.SelectedValue + ")";
                        string edoVenta = "";
                        Conexion(cad, edoVenta);
                        idPan = Int32.Parse(DropDownList1.SelectedValue);



                        cantidadFinalExistencia = cantidadExistencias - cantidadPan;
                        query = "UPDATE Inventario_Existencias SET Cantidad_Existencias=" + cantidadFinalExistencia + " WHERE ID_Inventario=1 AND ID_Pan =" + DropDownList1.SelectedValue;
                        comando = new SqlCommand(query, conexion);
                        comando.ExecuteNonQuery();
                        conexion.Close();
                        lblErrorMessage.Text = "";
                        lblErrorMessage2.Text = "";
                        ban = true;

                        Total_Venta();
                        lblTotal.Text = Total_Venta().ToString();
                        GridViewProductos();
                    }
                    if (ban==false)
                    {
                        lblErrorMessage2.Text = "No hay la suficiente cantidad de pan en inventario, sobran: "+ cantidadExistencias + " piezas";
                    }
                    
                }
                //-------------------------------
                

            }
            catch (Exception ex)
            {
                lblErrorMessage2.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCantidad.Text!= "")
                {
                    RelacionInventario();
                }
                else
                {
                    lblErrorMessage.Text = "Ingrese correctamente los datos";
                }
                
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            
        }
        /*-----------------------------------AGREGAR PRODUCTOS A LA TABLA-----------------------------*/
        public void GridViewProductos()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(cnn))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Pan.Nombre_Pan, Pan.Precio_Pan, Detalle_Venta.Cantidad_Detalle, Detalle_Venta.Subtotal_Detalle FROM Detalle_Venta  INNER JOIN Pan  ON Detalle_Venta.ID_Pan = Pan.ID_Pan WHERE Detalle_Venta.ID_Venta=" + idVentas, sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvVentas.DataSource = dtbl;
                gvVentas.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvVentas.DataSource = dtbl;
                gvVentas.DataBind();
                gvVentas.Rows[0].Cells.Clear();
                gvVentas.Rows[0].Cells.Add(new TableCell());
                gvVentas.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvVentas.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvVentas.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        /*-----------------------------------OBETENER TOTAL DE VENTA----------------------------*/
        public double Total_Venta()
        {
            double totalVenta = 0.0;
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    string query = "SELECT SUM(Subtotal_Detalle) from Detalle_Venta WHERE ID_Venta=" + idVentas;
                    SqlCommand comando = new SqlCommand(query, conexion);

                    /*SqlDataReader myReader = comando.ExecuteReader();*/

                    totalVenta = Double.Parse(comando.ExecuteScalar().ToString());
                    conexion.Close();
                }
                //-------------------------------
                lblErrorMessage.Text = "";
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            return totalVenta;
        }

        
        /*-----------------------------------TERMINAR VENTA----------------------------*/
        public void Venta()
        {
            try
            {
                double cantidadTotalVenta = double.Parse(lblTotal.Text);
                string query = "UPDATE Venta SET Total_Venta=" + cantidadTotalVenta + " WHERE ID_Venta=" + idVentas;
                string edoVenta = "Venta terminada";
                Conexion(query, edoVenta);
                
                lblErrorMessage.Text = "";
                
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Venta();
        }

        //CONEXION BD
        public void Conexion(string query, string edoVenta)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    lblErrorMessage.Text = "";
                    if(edoVenta == "Venta iniciada")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mostrar", "VentaIniciada();", true);
                    }
                    if (edoVenta == "Venta terminada")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mostrar", "VentaAgregada();", true);
                    }
                }
                
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }

        }

        
    }
}