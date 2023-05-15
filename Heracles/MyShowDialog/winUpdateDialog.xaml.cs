using System.Windows;

namespace Heracles.MyShowDialog
{
    public partial class winUpdateDialog : Window
    {
        public winUpdateDialog()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }
    }
}
