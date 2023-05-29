using HeraclesDAO.Logic;
using System.Windows;
using System.Windows.Input;
using HeraclesDAO.Models;
using System;
using Heracles.MyShowDialog;
using Heracles.Utilities;

namespace Heracles.Inscriptions
{
    public partial class winFormInscription : Window
    {
        MembresyImpl membresyImpl;
        Member _member;
        Inscription _inscription;
        InscriptionImpl _inscriptionImpl;

        Validate validate;

        int _inscriptionId = 0;
        int _memberId = 0;

        public winFormInscription()
        {
            InitializeComponent();
            FillComboBox();
            DefaultValues();
        }

        void FillComboBox()
        {
            membresyImpl = new MembresyImpl();
            cmbMembresy.ItemsSource = membresyImpl.GetMembresies().DefaultView;
        }

        void DefaultValues()
        {
            cmbMembresy.SelectedIndex = 0;
            dtpStart.Text = DateTime.Now.ToShortDateString();
            dtpFinish.Text = DateTime.Now.ToShortDateString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ShowMessages();
            _member = new Member()
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                SecondLastName = txtSecondLastName.Text
            };

            _inscription = new Inscription()
            {
                Start = dtpStart.SelectedDate.Value,
                Finish = dtpFinish.SelectedDate.Value,
                MembresyId = short.Parse(cmbMembresy.SelectedValue.ToString())
            };
            _inscriptionImpl = new InscriptionImpl();
            try
            {
                if (Inputs())
                {
                    if (_inscriptionImpl.Insert(_member, _inscription) > 0)
                    {
                        winInsertDialog winInsertDialog = new winInsertDialog();
                        winInsertDialog.ShowDialog();
                    }
                    _member = null;
                    _inscription = null;
                    Close();
                    winMenuInscriptions menuInscriptions = new winMenuInscriptions();
                    menuInscriptions.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ShowMessages();
            _inscription = new Inscription()
            {
                Id = _inscriptionId,
                MembresyId = short.Parse(cmbMembresy.SelectedValue.ToString()),
                Start = dtpStart.SelectedDate.Value,
                Finish = dtpFinish.SelectedDate.Value
            };
            _member = new Member()
            {
                Id = _memberId,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                SecondLastName = txtSecondLastName.Text
            };
            _inscriptionImpl = new InscriptionImpl();
            try
            {
               if(Inputs())
                {
                    if (_inscriptionImpl.Update(_inscription, _member) > 0)
                    {
                        winUpdateDialog winUpdateDialog = new winUpdateDialog();
                        winUpdateDialog.ShowDialog();
                    }
                    Close();
                    winMenuInscriptions menuInscriptions = new winMenuInscriptions();
                    menuInscriptions.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Edit(Inscription inscription, Member member, string membresy)
        {
            _memberId = member.Id;
            _inscriptionId = inscription.Id;
            txbtitle.Text = "Editar";
            cmbMembresy.Text = membresy;
            dtpStart.Text = inscription.Start.ToString();
            dtpFinish.Text = inscription.Finish.ToString();
            txtName.Text = member.Name;
            txtLastName.Text = member.LastName;
            txtSecondLastName.Text = member.SecondLastName;
            Controls();
            ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winMenuInscriptions menuInscriptions = new winMenuInscriptions();
            menuInscriptions.ShowDialog();
        }

        #region Config
        void Controls()
        {
            btnSave.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
        }

        void ShowMessages()
        {
            txbErrorName.Visibility = Visibility.Collapsed;
            txbErrorLastName.Visibility = Visibility.Collapsed;
            txbErrorSecondLastName.Visibility = Visibility.Collapsed;
            txbErrorMembresy.Visibility = Visibility.Collapsed;
            txbErrorStartDate.Visibility = Visibility.Collapsed;
            txbErrorFinishDate.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Validations

        bool Inputs()
        {
            validate = new Validate();
            bool allValids = true;
            if (allValids)
            {
                if (!validate.Inputs(txtName.Text, 1))
                {
                    txbErrorName.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if(!validate.Inputs(txtLastName.Text, 1))
                {
                    txbErrorLastName.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if(!validate.Dates(dtpStart.SelectedDate.Value, 0))
                {
                    txbErrorStartDate.Text = "El rango de fecha no es correcto";
                    txbErrorStartDate.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if(dtpFinish.SelectedDate.Value < dtpStart.SelectedDate.Value)
                {
                    txbErrorFinishDate.Text = "La fecha de renovación no puede ser menor\n a la fecha de inscripción";
                    txbErrorFinishDate.Visibility = Visibility.Visible;
                    allValids = false;
                }
                return allValids;
            }
            return allValids;
        }

        private void txtSecondLastName_KeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.FieldTextValid(e);
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.FieldTextValid(e);
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.FieldTextValid(e);
        }
        #endregion
    }
}
