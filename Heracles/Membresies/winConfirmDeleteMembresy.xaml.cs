using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Windows;

namespace Heracles.Membresies
{
    /// <summary>
    /// Lógica de interacción para winConfirmDeleteMembresy.xaml
    /// </summary>
    public partial class winConfirmDeleteMembresy : Window
    {
        byte _id = 0;
        Membresy _membresy;
        MembresyImpl membresyImpl;

        public winConfirmDeleteMembresy()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            ShowMembresies showMembresies = new ShowMembresies();
            showMembresies.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _membresy = new Membresy()
            {
                Id = _id
            };
            membresyImpl = new MembresyImpl();

            try
            {
                membresyImpl.Delete(_membresy);
                Close();
                ShowMembresies showMembresies = new ShowMembresies();
                showMembresies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Confirm(Membresy membresy)
        {
            _id = membresy.Id;
            txbNameMembresy.Text = membresy.TypeMembresy.ToString();
            Show();
        }
    }
}
