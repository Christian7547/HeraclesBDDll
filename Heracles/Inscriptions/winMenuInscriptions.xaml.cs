using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Data;
using System.Windows;

namespace Heracles.Inscriptions
{
    public partial class winMenuInscriptions : Window
    {
        InscriptionImpl inscriptionImpl;
        Inscription _inscription;
        Member _member;

        public winMenuInscriptions()
        {
            InitializeComponent();
            inscriptionImpl = new InscriptionImpl();
            dtgData.ItemsSource = inscriptionImpl.Select().DefaultView;
            dtgData.Columns[0].Visibility = Visibility.Collapsed;
            dtgData.Columns[1].Visibility = Visibility.Collapsed;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnNewInscription_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winFormInscription formInscription = new winFormInscription();
            formInscription.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            _inscription = new Inscription();
            _inscription.Id = int.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString());
            string selectedMembresy = ((DataRowView)dtgData.SelectedItem).Row["Type"].ToString();
            _inscription.Start = DateTime.Parse(((DataRowView)dtgData.SelectedItem).Row["Start"].ToString());
            _inscription.Finish = DateTime.Parse(((DataRowView)dtgData.SelectedItem).Row["Finish"].ToString());

            _member = new Member()
            {
                Id = int.Parse(((DataRowView)dtgData.SelectedItem).Row["MemberId"].ToString()),
                Name = ((DataRowView)dtgData.SelectedItem).Row["Name"].ToString(),
                LastName = ((DataRowView)dtgData.SelectedItem).Row["LastName"].ToString(),
                SecondLastName = ((DataRowView)dtgData.SelectedItem).Row["SecondLastName"].ToString()
            };
            
            Close();
            winFormInscription formInscription = new winFormInscription();
            formInscription.Edit(_inscription, _member, selectedMembresy);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _inscription = new Inscription()
            {
                Id = int.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString())
            };
            _member = new Member()
            {
                Id = int.Parse(((DataRowView)dtgData.SelectedItem).Row["MemberId"].ToString())
            };
            Close();
            winDeleteInscription winDeleteInscription = new winDeleteInscription();
            winDeleteInscription.ConfirmDelete(_inscription, _member);
        }
    }
}
