using System.Data;
using System.Windows;
using HeraclesDAO.Logic;
using HeraclesDAO.Models;

namespace Heracles.Users
{
    /// <summary>
    /// Lógica de interacción para winShowUsers.xaml
    /// </summary>
    public partial class winShowUsers : Window
    {
        User _user;

        public winShowUsers()
        {
            InitializeComponent();
            Select();
        }

        void Select()
        {
            UserImpl userImpl = new UserImpl();
            dtgData.ItemsSource = userImpl.Select().DefaultView;
            dtgData.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            _user = new User()
            {
                Id = int.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString()),
                UserName = ((DataRowView)dtgData.SelectedItem).Row["UserName"].ToString(),
                Email = ((DataRowView)dtgData.SelectedItem).Row["Email"].ToString(),
                Role = ((DataRowView)dtgData.SelectedItem).Row["Role"].ToString()
            };
            Close();
            winNewUser winNewUser = new winNewUser();
            winNewUser.Edit(_user);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _user = new User()
            {
                Id = int.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString()),
                UserName = ((DataRowView)dtgData.SelectedItem).Row["UserName"].ToString(),
                Email = ((DataRowView)dtgData.SelectedItem).Row["Email"].ToString(),
                Role = ((DataRowView)dtgData.SelectedItem).Row["Role"].ToString()
            };
            Close();
            winDeleteUser winDeleteUser = new winDeleteUser();
            winDeleteUser.Confirm(_user);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            winNewUser winNewUser = new winNewUser();
            winNewUser.ShowDialog();
        }
    }
}
