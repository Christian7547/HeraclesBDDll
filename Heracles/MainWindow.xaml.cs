using Heracles.Coachs;
using Heracles.Membresies;
using System;
using System.Windows;

namespace Heracles
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtCurrentDate.Text = DateTime.Today.Date.ToShortDateString(); 
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

        #endregion
    }
}
