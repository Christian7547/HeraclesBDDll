using System;
using System.Web.UI;

namespace HeraclesWeb.Views
{
    public partial class MenuReceptionist : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["Role"] != "Recepcionista")
                Response.Redirect("Login");
        }
    }
}