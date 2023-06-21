using HeraclesDAO.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

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