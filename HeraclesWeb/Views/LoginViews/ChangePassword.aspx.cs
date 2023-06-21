using HeraclesDAO.Logic;
using HeraclesDAO.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.LoginViews
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        UserImpl userImpl;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            userImpl = new UserImpl();
            try
            {
                if(txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    int n = userImpl.ChangePassword(txtConfirmPassword.Text, txtoldPassword.Text);
                    if (n > 0)
                    {
                        switch (SessionClass.SessionRole)
                        {
                            case "Administrador":
                                Response.Redirect("Default");
                                break;
                            case "Recepcionista":
                                Response.Redirect("MenuReceptionist");
                                break;
                            case "Coach":
                                Response.Redirect("MenuCoach");
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            switch (SessionClass.SessionRole)
            {
                case "Administrador":
                    Response.Redirect("Default");
                    break;
                case "Recepcionista":
                    Response.Redirect("");
                    break;
                case "Coach":
                    Response.Redirect("");
                    break;
            }
        }
    }
}