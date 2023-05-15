using System.Windows;

namespace Heracles.MyShowDialog
{
    public partial class winInsertDialog : Window
    {
        public winInsertDialog()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
