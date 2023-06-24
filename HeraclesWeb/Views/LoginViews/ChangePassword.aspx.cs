using HeraclesDAO.Logic;
using HeraclesDAO.Models.Session;
using HeraclesWeb.Utilities;
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
        ValidateWeb validateWeb;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            ShowErrors();
            userImpl = new UserImpl();
            try
            {
                validateWeb = new ValidateWeb();
                if (txtNewPassword.Text == txtConfirmPassword.Text )
                {
                    if(validateWeb.Inputs(txtConfirmPassword.Text, 1))
                    {
                        int n = userImpl.ChangePassword(txtConfirmPassword.Text, txtoldPassword.Text);
                        if (n > 0)
                        {
                            Session["Role"] = null;
                            Response.Redirect("Login");
                        }
                        else
                        {
                            lblErrorOldPassword.Text = "La contraseña actual no es correcta";
                            lblErrorOldPassword.Visible = true;
                        }
                    }
                    else
                    {
                        lblErrorNewPassword.Text = "La contraseña debe contener al menos 8 digitos con al menos un número, una mayúscula, una minúscula y un caracter especial";
                        lblErrorNewPassword.Visible = true;
                    }
                }
                else
                {
                    lblErrorNewPassword.Text = "Las contraseñas no coinciden";
                    txtConfirmPassword.Text = "Las contraseñas no coinciden";
                    lblErrorNewPassword.Visible = true;
                    lblErrorPassword.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void ShowErrors()
        {
            lblErrorNewPassword.Visible = false;
            lblErrorOldPassword.Visible = false;
            lblErrorPassword.Visible = false;
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