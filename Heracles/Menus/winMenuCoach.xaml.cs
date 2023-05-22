using Heracles.Users;
using HeraclesDAO.Models.Session;
using System;
using System.Windows;

namespace Heracles.Menus
{
    public partial class winMenuCoach : Window
    {
        public winMenuCoach()
        {
            InitializeComponent();
            txtCurrentDate.Text = DateTime.Today.Date.ToShortDateString();
            txbOnLine.Text = SessionClass.SessionUserName;
        }

        #region AppConfig
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
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
