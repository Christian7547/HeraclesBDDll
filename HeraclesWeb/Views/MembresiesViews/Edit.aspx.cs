using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Web.UI;

namespace HeraclesWeb.Views.MembresiesViews
{
    public partial class Edit : Page
    {
        MembresyImpl membresyImpl;
        Membresy _membresy;

        protected void Page_Load(object sender, EventArgs e)
        {
            _membresy = (Membresy)Session["MembresyEdit"];
            if (_membresy != null)
            {
                txtId.Text = _membresy.Id.ToString();
                txtType.Text = _membresy.TypeMembresy;
                txtPrice.Text = _membresy.Price.ToString();
                Session.Remove("MembresyEdit");         //Clear session property object
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            _membresy = new Membresy()
            {
                Id = byte.Parse(txtId.Text),
                TypeMembresy = txtType.Text,
                Price = float.Parse(txtPrice.Text),
            };

            membresyImpl = new MembresyImpl();

            try
            {
                if (membresyImpl.Update(_membresy) > 0)
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