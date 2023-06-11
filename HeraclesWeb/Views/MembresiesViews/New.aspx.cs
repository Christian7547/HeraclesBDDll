using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HeraclesDAO.Models;
using HeraclesDAO.Logic;

namespace HeraclesWeb.Views.MembresiesViews
{
    public partial class New : System.Web.UI.Page
    {
        MembresyImpl membresyImpl;
        Membresy _membresy;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            membresyImpl = new MembresyImpl();

            _membresy = new Membresy()
            {
                TypeMembresy = txtType.Text,
                Price = float.Parse(txtPrice.Text),
            };

            try
            {
                if (membresyImpl.Insert(_membresy) > 0)
                    Response.Redirect("Membresies");
                _membresy = null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Membresies");
        }
    }
}