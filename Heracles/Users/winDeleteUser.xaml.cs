using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Heracles.Users
{
    /// <summary>
    /// Lógica de interacción para winDeleteUser.xaml
    /// </summary>
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
