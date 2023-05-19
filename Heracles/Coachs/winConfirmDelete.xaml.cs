using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Windows;

namespace Heracles.Coachs
{
    public partial class winConfirmDelete : Window
    {
        Coach _coach;
        CoachImpl coachImpl;
        byte _id = 0;

        public winConfirmDelete()
        {
            InitializeComponent();
        }

        public void Confirm(Coach coach)
        {
            _id = coach.Id;
            txbName.Text = coach.Name + " " + coach.LastName + " " + coach.SecondLastName;
            txbCi.Text = "C.I: " + coach.CI;
            txbPhone.Text = "Teléfono: " + coach.Phone;
            ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _coach = new Coach()
            {
                Id = _id 
            };
            coachImpl = new CoachImpl();
            try
            {
                coachImpl.Delete(_coach);
                Close();
                winShowCoachs winShowCoachs = new winShowCoachs();
                winShowCoachs.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winShowCoachs winShowCoachs = new winShowCoachs();
            winShowCoachs.ShowDialog();
        }
    }
}
