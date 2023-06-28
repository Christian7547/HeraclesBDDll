using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Web.UI;

namespace HeraclesWeb.Views.CoachsViews
{
    public partial class New : Page
    {
        CoachImpl coachImpl;
        Coach _coach;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            coachImpl = new CoachImpl();
            _coach = new Coach()
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                SecondLastName = txtSecondLastName.Text,
                CI = txtCI.Text,
                Phone = txtPhone.Text
            };
            
            try
            {
                if (coachImpl.Insert(_coach) > 0)
                    Response.Redirect("Coachs");
                _coach = null;
            }
            catch(Exception ex)
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