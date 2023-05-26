using Heracles.MyShowDialog;
using Heracles.Utilities;
using HeraclesDAO.Logic;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Heracles.Users.UpdateProfile
{
    public partial class winChangePassword : Window
    {
        UserImpl _userImpl;
        Validate validate;

        public winChangePassword()
        {
            InitializeComponent();
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            _userImpl = new UserImpl();
            try
            {
                winUpdatePasswordDialog passwordDialog;
                validate = new Validate();
                if (txtNewPassword.Password == txtConfirmPassword.Password && validate.Inputs(txtConfirmPassword.Password, 0))
                {
                    int n = _userImpl.ChangePassword(txtConfirmPassword.Password, txtOldPassword.Password);
                    if (n > 0)
                    {
                        passwordDialog = new winUpdatePasswordDialog();
                        passwordDialog.ShowMessage("Se restableció la contraseña");
                        Close();
                    }
                    else
                    {
                        passwordDialog = new winUpdatePasswordDialog();
                        passwordDialog.ShowMessage("Su contraseña actual no es correcta");
                    }
                }
                else
                {
                    passwordDialog = new winUpdatePasswordDialog();
                    passwordDialog.ShowMessage("No es posible actualizar la contraseña,\n debe contener números, minúsculas,\n mayúsculas y carácteres especiales");
                }
                txtOldPassword.Password = string.Empty;
                txtNewPassword.Password = string.Empty;
                txtConfirmPassword.Password = string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}