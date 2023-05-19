using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Windows;

namespace Heracles.Users
{
    public partial class winDeleteUser : Window
    {
        UserImpl userImpl;
        int _id = 0;
        User _user;

        public winDeleteUser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winShowUsers winShowUsers = new winShowUsers();
            winShowUsers.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            userImpl = new UserImpl();
            _user = new User()
            {
                Id = _id
            };

            try
            {
                userImpl.Delete(_user);
                Close();
                winShowUsers winShowUsers = new winShowUsers();
                winShowUsers.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Confirm(User user)
        {
            _id = user.Id;
            txbEmail.Text = "E-mail: " + user.Email; 
            txbUserName.Text = "Usuario: " + user.UserName;
            txbRole.Text = "Rol: " + user.Role;   
            ShowDialog();
        }
    }
}
