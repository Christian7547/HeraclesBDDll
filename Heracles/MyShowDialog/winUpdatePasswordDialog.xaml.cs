using System.Windows;

namespace Heracles.MyShowDialog
{
    public partial class winUpdatePasswordDialog : Window
    {
        public winUpdatePasswordDialog()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void ShowMessage(string message)
        {
            txbMessage.Text = message;  
            ShowDialog();
        }
    }
}
