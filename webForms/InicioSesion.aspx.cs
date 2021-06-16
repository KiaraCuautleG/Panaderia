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
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            lbl2.Text = "Registro exitoso";
                            Response.Redirect("Ventas.aspx");

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