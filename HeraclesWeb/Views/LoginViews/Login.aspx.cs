using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using HeraclesDAO.Models.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.LoginViews
{
    public partial class Login : Page
    {
        UserImpl _userImpl;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Role"] = null;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            _userImpl = new UserImpl();
            DataTable login = _userImpl.Login(txtUsername.Text, txtPassword.Text);
            try
            {
                if(login.Rows.Count > 0)
                {
                    Session["Role"] = login.Rows[0][2].ToString();
                    SessionClass.SessionId = int.Parse(login.Rows[0][0].ToString());
                    SessionClass.SessionUserName = login.Rows[0][1].ToString();
                    SessionClass.SessionEmail = login.Rows[0][3].ToString();

                    switch ((string)Session["Role"])
                    {
                        case "Administrador":
                            Response.Redirect(ResolveUrl("~/Views/Default"));
                            break;
                        case "Recepcionista":
                            Response.Redirect(ResolveUrl("~/Views/MenuReceptionist.aspx"));
                            break;
                        case "Coach":
                            Response.Redirect(ResolveUrl("~/Views/MenuCoach.aspx"));
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}