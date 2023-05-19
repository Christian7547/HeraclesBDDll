using System.Windows;

namespace Heracles.Login
{
    public partial class winIncorrectLogin : Window
    {
        public winIncorrectLogin()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }
    }
}
