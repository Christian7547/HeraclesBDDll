using System.Windows;

namespace Heracles.Login
{
    /// <summary>
    /// Lógica de interacción para winIncorrectLogin.xaml
    /// </summary>
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
