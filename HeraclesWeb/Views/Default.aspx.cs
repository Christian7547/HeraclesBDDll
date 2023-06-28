using System;
using System.Web.UI;

namespace HeraclesWeb.Views
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["Role"] != "Administrador")
                Response.Redirect("Login");
        }
    }
}