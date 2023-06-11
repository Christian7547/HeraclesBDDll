using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.CoachsViews
{
    public partial class Edit : Page
    {
        CoachImpl coachImpl;
        Coach _coach;

        protected void Page_Load(object sender, EventArgs e)
        {
            _coach = (Coach)Session["EditCoach"];
            if(_coach != null)
            {
                txtId.Text = _coach.Id.ToString();
                txtName.Text = HttpUtility.HtmlDecode(_coach.Name); //HttpUtility.Decode: Decodes special characters that can be confused with HTML
                txtLastName.Text = HttpUtility.HtmlDecode(_coach.LastName);
                txtSecondLastName.Text = HttpUtility.HtmlDecode(_coach.SecondLastName);
                txtCI.Text = _coach.CI;
                txtPhone.Text = _coach.Phone;
                Session.Remove("EditCoach");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            _coach = new Coach()
            {
                Id = byte.Parse(txtId.Text),
                Name = txtName.Text,
                LastName = txtLastName.Text,
                SecondLastName = txtSecondLastName.Text,
                CI = txtCI.Text,
                Phone = txtPhone.Text
            };
            coachImpl = new CoachImpl();
            try
            {
                if (coachImpl.Update(_coach) > 0)
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