using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Panaderia
{
    public partial class InicioSesion : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl2.Text = "";
            }
        }
        public void Login()
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Email_Usuario, Contraseña_Usuario FROM Usuario WHERE Email_Usuario='" + txtUsuario.Text + "' AND Contraseña_Usuario ='" + txtContraseña.Text+ "'", conexion))
                    {
                        /*Los objetos DataReader se utilizan para leer datos en situaciones en las que es 
                         * necesario el acceso una única vez, y de solo lectura, como cuando accedemos a una 
                         * contraseña almacenada, o se cumplimenta un control enlazado a una lista.*/
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            lbl2.Text = "Registro exitoso";
                            Response.Redirect("Ventas.aspx");
                            conexion.Close();

                        }
                        else
                        {
                            lbl2.Text = "Usuario no encontrado, verifique sus datos";
                        }

                    }
                }
            }catch (Exception ex)
            {
                lbl1.Text = ex.ToString();
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}