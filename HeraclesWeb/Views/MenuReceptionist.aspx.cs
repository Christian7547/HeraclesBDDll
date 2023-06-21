using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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