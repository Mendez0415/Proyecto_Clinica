using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Clinica
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            //Abandonar la sesion
            Session.Abandon();
            //Redirigir a la pagina Login.aspx
            Response.Redirect("Login.aspx");
        }
    }
}