using Heracles.MyShowDialog;
using HeraclesDAO.Logic;
using HeraclesDAO.Models.Session;
using System;
using System.Text;
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

                if (txtNewPassword.Password == txtConfirmPassword.Password )
                {
                    int n = _userImpl.ChangePassword(txtConfirmPassword.Password, txtOldPassword.Password);
                    if (n > 0)
                    {
                        passwordDialog = new winUpdatePasswordDialog();
                        passwordDialog.ShowMessage("Se restableció la contraseña");
                    }
                }
                else
                {
                    passwordDialog = new winUpdatePasswordDialog();
                    passwordDialog.ShowMessage("No es posible actualizar la contraseña");
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
            Regex regex = new Regex(@"^[a-zA-Z]{8,60}$");
            if (regex.IsMatch(password))
                return true;
            else
                return false;
        }
    }
}
