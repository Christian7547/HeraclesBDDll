using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System.Data;
using System.Windows;

namespace Heracles.Membresies
{
    /// <summary>
    /// Lógica de interacción para ShowMembresies.xaml
    /// </summary>
    public partial class ShowMembresies : Window
    {
        MembresyImpl membresyImpl;
        Membresy membresy;

        public ShowMembresies()
        {
            InitializeComponent();
            Select();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnNewMembresy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            winNewMembresie winNewMembresie = new winNewMembresie();
            winNewMembresie.ShowDialog();
        }

        public void Select()
        {
            membresyImpl = new MembresyImpl();
            dtgData.ItemsSource = membresyImpl.Select().DefaultView;
            dtgData.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            membresy = new Membresy()
            {
                Id = byte.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString()),
                TypeMembresy = ((DataRowView)dtgData.SelectedItem).Row["Type"].ToString(),
                Price = float.Parse(((DataRowView)dtgData.SelectedItem).Row["Price"].ToString()),
            };
            this.Close();
            winNewMembresie winNewMembresie = new winNewMembresie();
            winNewMembresie.Edit(membresy);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            membresy = new Membresy()
            {
                Id = byte.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString()),
                TypeMembresy = ((DataRowView)dtgData.SelectedItem).Row["Type"].ToString(),
                Price = float.Parse(((DataRowView)dtgData.SelectedItem).Row["Price"].ToString()),
            };
            this.Close();
            winConfirmDeleteMembresy deleteMembresy = new winConfirmDeleteMembresy();
            deleteMembresy.Confirm(membresy);
        }
    }
}
