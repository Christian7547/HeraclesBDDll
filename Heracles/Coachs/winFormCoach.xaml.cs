using Heracles.Membresies;
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

namespace Heracles.Coachs
{
    /// <summary>
    /// Lógica de interacción para winFormCoach.xaml
    /// </summary>
    public partial class winFormCoach : Window
    {
        Coach _coach;
        CoachImpl coachImpl;
        byte _id = 0;

        public winFormCoach()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _coach = new Coach()
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                SecondLastName = txtSecondLastName.Text,
                CI = txtCI.Text,
                Phone = txtPhone.Text
            };
            coachImpl = new CoachImpl();
            try
            { 
                int success = coachImpl.Insert(_coach);
                if(success > 0)
                {
                    MessageBox.Show("Registro guardado correctamente");
                }
                _coach = null;
                Close();
                winShowCoachs winShowCoachs = new winShowCoachs();
                winShowCoachs.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            _coach = new Coach()
            {
                Id = _id,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                SecondLastName = txtSecondLastName.Text,
                CI = txtCI.Text,
                Phone = txtPhone.Text
            };

            coachImpl = new CoachImpl();
            try
            {
                int success = coachImpl.Update(_coach);
                if(success > 0)
                    MessageBox.Show("Registro modificado");

                _coach = null;

                this.Close();
                winShowCoachs showCoachs = new winShowCoachs();
                showCoachs.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Edit(Coach coach)
        {
            txtName.Text = coach.Name;
            txtLastName.Text = coach.LastName;
            txtSecondLastName.Text = coach.SecondLastName;
            txtCI.Text = coach.CI;  
            txtPhone.Text = coach.Phone; 
            _id = coach.Id;
            EditControls();
            ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winShowCoachs showCoachs = new winShowCoachs();
            showCoachs.ShowDialog();
        }

        void EditControls()
        {
            btnSave.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            txbtitle.Text = "Editar";
        }
    }
}
