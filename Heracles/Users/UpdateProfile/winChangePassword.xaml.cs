using Heracles.MyShowDialog;
using HeraclesDAO.Logic;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Heracles.Users.UpdateProfile
{
    public partial class winChangePassword : Window
    {
        UserImpl _userImpl;

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

                if (txtNewPassword.Password == txtConfirmPassword.Password && ValidPassword(txtConfirmPassword.Password))
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

        bool ValidPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*\p{P})(?!.*\s).{8,16}$");
            if (regex.IsMatch(password))
                return true;
            else
                return false;
        }
    }
}
