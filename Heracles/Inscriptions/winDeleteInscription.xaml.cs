using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Windows;

namespace Heracles.Inscriptions
{
    public partial class winDeleteInscription : Window
    {
        int _id = 0;
        int _idMember = 0;
        Member _member;
        Inscription _inscription;
        InscriptionImpl _inscriptionImpl;

        public winDeleteInscription()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _inscription = new Inscription()
            {
                Id = _id
            };
            _member = new Member()
            {
                Id = _idMember
            };
            _inscriptionImpl = new InscriptionImpl();
            try
            {
                _inscriptionImpl.Delete(_inscription, _member);
                Close();
                winMenuInscriptions menuInscriptions = new winMenuInscriptions();
                menuInscriptions.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winMenuInscriptions menuInscriptions = new winMenuInscriptions();
            menuInscriptions.ShowDialog();
        }

        public void ConfirmDelete(Inscription inscription, Member member)
        {
            _id = inscription.Id;
            _idMember = member.Id;
            ShowDialog();
        }
    }
}
