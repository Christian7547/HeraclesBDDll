using System;
using System.Web.UI;

namespace HeraclesWeb.Views
{
    public partial class MenuCoach : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["Role"] != "Coach")
                Response.Redirect("Login");
        }
    }
}