using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.MembresiesViews
{
    public partial class Delete : System.Web.UI.Page
    {
        MembresyImpl membresyImpl;
        Membresy _membresy;

        protected void Page_Load(object sender, EventArgs e)
        {
            _membresy = (Membresy)Session["DeleteMembresy"];
            if (_membresy != null)
            {
                txtId.Text = _membresy.Id.ToString();
                lblType.Text = _membresy.TypeMembresy;
                lblPrice.Text = _membresy.Price.ToString();
                Session.Remove("DeleteMembresy");        
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowMembresies.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            _membresy = new Membresy()
            {
                Id = byte.Parse(txtId.Text),
                TypeMembresy = lblType.Text,
                Price = float.Parse(lblPrice.Text)
            };

            membresyImpl = new MembresyImpl();
            try
            {
                if (membresyImpl.Delete(_membresy) > 0)
                    Response.Redirect("ShowMembresies.aspx");
                _membresy = null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}