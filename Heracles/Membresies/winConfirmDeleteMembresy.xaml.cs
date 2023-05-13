using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            try
            {
                _membresy = new Membresy()
                {
                    Id = _id
                };
                membresyImpl = new MembresyImpl();
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
