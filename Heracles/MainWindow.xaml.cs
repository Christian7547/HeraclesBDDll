using Heracles.Coachs;
using Heracles.Inscriptions;
using Heracles.Membresies;
using Heracles.Users;
using HeraclesDAO.Models.Session;
using System;
using System.Windows;

namespace Heracles
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtCurrentDate.Text = DateTime.Today.Date.ToShortDateString();
            txbOnLine.Text = SessionClass.SessionUserName;
        }
        #region ConfigApplication
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        #endregion

        #region Options
        private void btnMembresies_Click(object sender, RoutedEventArgs e)
        {
            ShowMembresies showMembresies = new ShowMembresies();
            showMembresies.ShowDialog();
        }

        private void btnCoachs_Click(object sender, RoutedEventArgs e)
        {
            winShowCoachs winShowCoachs = new winShowCoachs();
            winShowCoachs.ShowDialog(); 
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            winShowUsers winShowUsers = new winShowUsers();
            winShowUsers.ShowDialog();
        }

        private void btnInscriptions_Click(object sender, RoutedEventArgs e)
        {
            winMenuInscriptions menuInscriptions = new winMenuInscriptions();
            menuInscriptions.ShowDialog();
        }

        #endregion

        #region PopupMenu
        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            winProfile winProfile = new winProfile();   
            winProfile.ShowDialog();
        }
        #endregion
    }
}
