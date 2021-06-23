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
        /*idVentas es estatico ya que a lo largo de toda esta pagina estaremos usando ese valor*/
        static int idVentas= 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenadoDropDown();
                ObtenerIdVenta();
                /*Al cargar por primera vez la parte de agregar productos a la venta y la parte de enviar estarán
                 inhabilitados, se deshabilitan con la propiedad enable, esto para que al iniciar la venta se habilita */
                txtCantidad.Enabled = false;
                DropDownList1.Enabled = false;
                btnAgregar.Enabled = false;
                btnEnviar.Enabled = false;

            }
        }

        /*Esta funcion nos a ayuda a añadirle 1 al ultimo id y así que se muestre el idVenta de la nueva venta*/
        public void ObtenerIdVenta()
        {
            string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(cnn))
            {
                conexion.Open();
                /*Con esta sentencia se obtiene el ultimo id de la venta*/
                string query = "SELECT TOP 1 [ID_Venta] FROM Venta ORDER BY [ID_Venta] DESC ";
                SqlCommand comando = new SqlCommand(query, conexion);

                /*Se le suma 1 al ultimo id de la venta para que ese sea el id de la nueva venta*/
                /*Double.Parse - para convertir de string a double*/
                /*ExecuteScalar - Ejecuta la consulta y devuelve la primera columna de la primera fila del conjunto de resultados devuelto por la consulta.*/
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
                /*Se valida que haya seleccionado una fecha en el calendario, como esta por defecto la fecha
                 01/01/0001, por lo tanto si no es esa fecha es porque si seleccionaron alguna fecha*/
                if(Calendar1.SelectedDate.ToShortDateString() != "01/01/0001")
                {
                    idVentas = Int32.Parse(lblIDVenta.Text);
                    double total = 0;
                    string fecha = Calendar1.SelectedDate.Year.ToString() + "-" + Calendar1.SelectedDate.Month.ToString() + "-" + Calendar1.SelectedDate.Day.ToString();
                    string cad = "INSERT INTO Venta(ID_Venta, Fecha_Venta, Total_Venta, ID_Usuario) VALUES (" + idVentas + ",'" + fecha + "'," + total + ", '1')";
                    string edoVenta = "Venta iniciada";

                    /*Como habían procesos que tenian la misma forma a la conexion a la bd mejor hice una
                     funcion, donde se le pasa la cadena y el estado de la venta*/
                    Conexion(cad, edoVenta);


                    /*Al seleccionar una fecha del calendario y se insertan la venta se habilitará todos los campos posteriores*/
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
            /*Se llena el DropDownList con informacion del inventario por lo que se manda la sentencia*/
            DropDownList1.DataSource = DropDownConexion("SELECT Inventario_Existencias.ID_Pan, Pan.Nombre_Pan FROM Inventario_Existencias JOIN Pan ON Inventario_Existencias.ID_Pan = Pan.ID_Pan");
            
            DropDownList1.DataTextField = "Nombre_Pan"; /*Lo que se visualizara será los nombre de los panes*/
            DropDownList1.DataValueField = "ID_Pan"; /*El valor que se seleccionara será el ID_Pan al seleccionar algun pan*/
            DropDownList1.DataBind(); /*lo que hace este metodo es enlazar los datos del origen de datos al control*/
            DropDownList1.Items.Insert(0, new ListItem("[Selecccionar]", "0")); /*Esta opcion es la que saldrá por defecto en el dropDown */
            
        }
        
        public DataSet DropDownConexion(string query)
        {
            /*Un DataSet es un objeto que almacena n número de DataTables, estas tablas puedes estar 
             * conectadas dentro del dataset. La creación de un DataSet es similar al de un DataTable*/
            /*Basicamente es para que almacene una cierta cantidad de datos*/
            DataSet ds = new DataSet(); ;
            try
            {
                /*la cadena de conexion a la bd*/
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();/*Se abre la conexion a la bd*/

                    /*SqlCommand representa un procedimiento almacenado o una instrucción de 
                     * Transact-SQL que se ejecuta en una base de datos de SQL Server. */
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
        /*Funcion que returna el precio de cada producto que se elija*/
        public double LlenadoPrecio()
        {
            double precioPan = 0.0;
            try
            {

                //Obtener precio de pan ---
                /*la cadena de conexion a la bd*/
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    /*Dependiendo del pan seleccionado se obtendrá el precio del pan*/
                    string query = "SELECT Precio_Pan FROM Pan WHERE ID_Pan =" + DropDownList1.SelectedValue;
                    SqlCommand comando = new SqlCommand(query, conexion);

                    /*SqlDataReader myReader = comando.ExecuteReader();*/

                    /*se convierte a double el resultado de la sentencia sql*/
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

        /*Al agregar productos a la venta por producto se irán restando en el inventario*/
        public void RelacionInventario()
        {
            try
            {
                double cantidadExistencias;
                double cantidadFinalExistencia;
                int cantidadPan;
                bool ban = false;
                cantidadPan = Int32.Parse(txtCantidad.Text);
                /*la cadena de conexion a la bd*/
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    /*se abre la conexion*/
                    conexion.Open();
                    //Obtener cantidad de existencias para luego dependiendo de lo que se venda se restarán ---
                    string query = "SELECT Cantidad_Existencias FROM Inventario_Existencias WHERE ID_Inventario=1 AND ID_Pan =" + DropDownList1.SelectedValue;
                    SqlCommand comando = new SqlCommand(query, conexion);

                    cantidadExistencias = double.Parse(comando.ExecuteScalar().ToString());

                    //si es mayor la cantidad de los panes en el inventario se pondrán vender el pan solicitado
                    if(cantidadExistencias> cantidadPan)
                    {
                        

                        double subtotal;
                        int idPan;

                        //se obiene el subtotal para ingresarlo en detalle_ventas
                        subtotal = cantidadPan * LlenadoPrecio();

                        /*Se ingresa a detalles ventas*/
                        string cad = "INSERT INTO Detalle_Venta VALUES (" + idVentas + "," + cantidadPan + "," + subtotal + "," + DropDownList1.SelectedValue + ")";
                        
                        /*Como no hay estado de inicio o finalizar de ventas no se pone nada en el string */
                        string edoVenta = "";

                        /*Se manda la conexion*/
                        Conexion(cad, edoVenta);
                        idPan = Int32.Parse(DropDownList1.SelectedValue);


                        //Reducir las existencias 
                        cantidadFinalExistencia = cantidadExistencias - cantidadPan;
                        query = "UPDATE Inventario_Existencias SET Cantidad_Existencias=" + cantidadFinalExistencia + " WHERE ID_Inventario=1 AND ID_Pan =" + DropDownList1.SelectedValue;
                        comando = new SqlCommand(query, conexion);

                        /*se ejecuta el comando sql*/
                        comando.ExecuteNonQuery();
                        conexion.Close();
                        lblErrorMessage.Text = "";
                        lblErrorMessage2.Text = "";
                        ban = true;

                        /*Aqui se manda a llamar esta funcion para que nos indique cuanto lleva como final de venta*/
                        Total_Venta();
                        lblTotal.Text = Total_Venta().ToString();

                        /*Manda a llamar la tabla con la que visualizaremos los productos que se van seleccionando */
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
                /*si ha instroducido alguna cantidad podrá procedir con la venta*/
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
                /*El SqlDataAdapter, actúa como puente entre un DataSet y SQL Server para recuperar
                 * y guardar datos y proporciona este puente mediante la asignación de Fill,*/
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Pan.Nombre_Pan, Pan.Precio_Pan, Detalle_Venta.Cantidad_Detalle, Detalle_Venta.Subtotal_Detalle FROM Detalle_Venta  INNER JOIN Pan  ON Detalle_Venta.ID_Pan = Pan.ID_Pan WHERE Detalle_Venta.ID_Venta=" + idVentas, sqlCon);
               
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                /*DataSource hace referencia a la fuente de datos,*/
                gvVentas.DataSource = dtbl;
                /*lo que hace este metodo es enlazar los datos del origen de datos al control*/
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
                    /*se suma todas las subventas de una misma venta para después cambiar el monto total de la venta*/
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
                //se se cambia la cantidad final en la venta por lo recuperamos el total de la venta
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
        /*este metodo se usa como tres o cuatro veces*/
        public void Conexion(string query, string edoVenta)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    SqlCommand comando = new SqlCommand(query, conexion);
                    /*ejecuta el comando sql*/
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    lblErrorMessage.Text = "";
                    /*dependiendo del estado de la venta o metodo que se llame es como va a devolver una funcion javascript*/
                    if (edoVenta == "Venta iniciada")
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