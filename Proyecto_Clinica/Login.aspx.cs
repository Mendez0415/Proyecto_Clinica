using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace Proyecto_Clinica
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Toma el texto escrito por el usuario en el campo usuario, y lo almacena en la variable 
            //.TRIM Elimina cualquier espacio en blanco
            string NombreUsuario = txtUsuario.Text.Trim();
            //Obtiene la contrseña del campo contraseña
            string contraseña = txtContrasena.Text;

            //Buscar la cadena de conexion en el archivo web.config 
            string connectionString = WebConfigurationManager.ConnectionStrings["ProyectoClinicaDB"].ConnectionString;

            //CONSULTA SQL- Donde se dice a la base de datos- Buscar el Tipo de usuario
            //de la tabla usuarios donde el usuario y contraseña coinsidan
            string query = "SELECT `Tipo de Usuario` FROM Usuarios WHERE NombreUsuario = @Usuario AND Contraseña = @Contraseña";

            //Crea una nueva conexxion a la base de datos usando la cadena de conexion
            //Donde using se encarga de abrir y cerrar 
            using (MySqlConnection con  = new MySqlConnection(connectionString) )
            {
                //Comando SQL, instruccion que se le envia a la base de datos
                //se le pasa la consulta de query y la conexion con
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    //Aqui se asignan los valores reales a los parametros @usuario y @Contraseña
                    //que se definio en la consulta 
                    cmd.Parameters.AddWithValue("@Usuario", NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                    try
                    {
                        //Abre la conexion, si no la base de datos no esta abierta
                        //se produce un error 
                        con.Open();

                        //Busca el tipo de usuario si no lo encuentra devuelve null
                        object tipoUsuario = cmd.ExecuteScalar();

                        //si tipo de usuario devuelve algo diferente de null existe esas credenciales
                        if (tipoUsuario != null)
                        {
                            //Si el login es exitoso, se guarda el tipo de usuario
                            //y el nombre de usuario en sesion (la sesion es como uan memoria temporal mientras se navega)
                            string tipo = tipoUsuario.ToString();
                            Session["TipoUsuario"] = tipo;
                            Session["NombreUsuario"] = NombreUsuario;

                            //Dependiendo el tipo de usuario se va redirigir 
                            if (tipo == "Doctor")
                            {
                                //Envia al usuario a la url especificada
                                Response.Redirect("Doctor.aspx");
                            }
                            else if (tipo == "Enfermero")
                            {
                                Response.Redirect("Enfermero.aspx");
                            }
                        }
                        else
                        {
                            lblMensaje.Text = "Usuario o contraseña incorrectos.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "Error al conectar con la base de datos: " + ex.Message;
                    }
                }
            }
        }
    }
}