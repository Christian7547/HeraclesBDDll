using System;
using System.Windows;
using Heracles.MyShowDialog;
using HeraclesDAO.Logic;
using HeraclesDAO.Logic.CreateUser;
using HeraclesDAO.Models;

namespace Heracles.Users
{
    /// <summary>
    /// Lógica de interacción para winNewUser.xaml
    /// </summary>
    public partial class winNewUser : Window
    {
        UserImpl userImpl;
        User _user;
        int _id = 0;

        public winNewUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            userImpl = new UserImpl();
            try
            {
                _user = new User()
                {
                    Email = txtEmail.Text,
                    UserName = txtUserName.Text,
                    Password = GenerateNewPassword(),
                    Role = cmbRole.Text
                };

                int save = userImpl.Insert(_user);
                if (save > 0)
                {
                    winInsertDialog winInsertDialog = new winInsertDialog();
                    winInsertDialog.ShowDialog();
                }
                else
                    MessageBox.Show("No se puedo guardar el registro");
                MessageBox.Show("Usuario = " + _user.UserName + " Password = " + _user.Password);
                _user = null;
                Close();
                winShowUsers winShowUsers = new winShowUsers();
                winShowUsers.ShowDialog();
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            _user = new User()
            {
                Id = _id,
                Email = txtEmail.Text,
                UserName = txtUserName.Text,
                Role = cmbRole.Text
            };
            userImpl = new UserImpl();
            try
            {
                int save = userImpl.Update(_user);
                if (save > 0)
                {
                    winUpdateDialog winUpdateDialog = new winUpdateDialog();
                    winUpdateDialog.ShowDialog();
                }
                else
                    MessageBox.Show("No se actualizó el registro");
                _user = null;
                Close();
                winShowUsers winShowUsers= new winShowUsers();
                winShowUsers.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Edit(User user)
        {
            _id = user.Id;
            txtEmail.Text = user.Email;
            txtUserName.Text = user.UserName;
            cmbRole.Text = user.Role;
            txtUserName.IsEnabled = true;
  
            EditControls();
            ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
            winShowUsers winShowUsers = new winShowUsers();
            winShowUsers.ShowDialog();
        }

        void EditControls()
        {
            btnSave.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            txbName.Visibility = Visibility.Collapsed;
            txbLastName.Visibility = Visibility.Collapsed;
            txtName.Visibility = Visibility.Collapsed;
            txtLastName.Visibility = Visibility.Collapsed;
            txbtitle.Text = "Editar";
        }

        #region Create New User
        private void btnGenerateUser_Click(object sender, RoutedEventArgs e)
        {
            GenerateNewUser(txtName.Text, txtLastName.Text, txtEmail.Text);
        }

        void GenerateNewUser(string name, string lastName, string email)
        {
            txtUserName.Text = string.Empty;
            NewUser newUser = new NewUser();
            txtUserName.Text = newUser.GenerateUserName(name, lastName, email);   
        }

        string GenerateNewPassword()
        {
            NewUser newUser = new NewUser();
            return newUser.GeneratePassword();
        }
        #endregion
    }
}
