using HeraclesDAO.Logic;
using HeraclesDAO.Models.Session;
using System;
using System.Data;
using System.Web.UI;

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
            lblErrorLogin.Visible = false;
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
                else
                {
                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    lblErrorLogin.Text = "Usuario y/o contraseña incorrectos. Verifique los datos y vuelva a intentarlo.";
                    lblErrorLogin.Visible = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}