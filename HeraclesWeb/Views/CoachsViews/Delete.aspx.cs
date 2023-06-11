using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HeraclesWeb.Views.CoachsViews
{
    public partial class Delete : Page
    {
        CoachImpl coachImpl;
        Coach _coach;

        protected void Page_Load(object sender, EventArgs e)
        {
            _coach = (Coach)Session["DeleteCoach"];
            if (_coach != null)
            {
                txtId.Text = _coach.Id.ToString();
                lblCompleteName.Text = _coach.Name + " " + _coach.LastName + " " + _coach.SecondLastName;
                lblCi.Text = _coach.CI;
                lblPhone.Text = _coach.Phone;
                Session.Remove("DeleteCoach");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            _coach = new Coach()
            {
                Id = byte.Parse(txtId.Text)
            };
            coachImpl = new CoachImpl();
            try
            {
                if (coachImpl.Delete(_coach) > 0)
                    Response.Redirect("Coachs");
                _coach = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Coachs");
        }
    }
}