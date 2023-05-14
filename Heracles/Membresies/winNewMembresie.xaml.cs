using HeraclesDAO.Models;
using HeraclesDAO.Logic;
using System.Windows;
using System;

namespace Heracles.Membresies
{
    /// <summary>
    /// Lógica de interacción para winNewMembresie.xaml
    /// </summary>
    public partial class winNewMembresie : Window
    {
        Membresy _membresy;
        MembresyImpl membresyImpl;
        byte _Id = 0;
        

        public winNewMembresie()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _membresy = new Membresy
            {
                TypeMembresy = txtType.Text,
                Price = float.Parse(txtPrice.Text)
            };
            membresyImpl = new MembresyImpl();
            try
            {
                int success = membresyImpl.Insert(_membresy);
                if (success > 0)
                    MessageBox.Show("Registro guardado correctamente");
                _membresy = null;
                Close();
                ShowMembresies showMembresies = new ShowMembresies();
                showMembresies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            ShowMembresies showMembresies = new ShowMembresies();
            showMembresies.ShowDialog();
        }

        public void Edit(Membresy membresy)
        {
            txtType.Text = membresy.TypeMembresy.ToString();
            txtPrice.Text = membresy.Price.ToString();
            _Id = membresy.Id;
            EditControls();
            Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            _membresy = new Membresy()
            {
                Id = this._Id,
                TypeMembresy = txtType.Text,
                Price = float.Parse(txtPrice.Text)
            };
            try
            {
                membresyImpl = new MembresyImpl();
                int success = membresyImpl.Update(_membresy);
                if(success > 0)
                    MessageBox.Show("Registro modificado");
                this.Close();
                ShowMembresies showMembresies = new ShowMembresies();
                showMembresies.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void EditControls()
        {
            btnSave.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            txbtitle.Text = "Editar";
        }
    }
}