using Heracles.Users.UpdateProfile;
using HeraclesDAO.Models.Session;
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
    /// Lógica de interacción para winProfile.xaml
    /// </summary>
    public partial class winProfile : Window
    {
        public winProfile()
        {
            InitializeComponent();
            txbEmailSession.Text = SessionClass.SessionEmail;
            txbRoleSession.Text = SessionClass.SessionRole;
            txbUserNameSession.Text = SessionClass.SessionUserName;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winChangePassword winChangePassword = new winChangePassword();
            winChangePassword.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
