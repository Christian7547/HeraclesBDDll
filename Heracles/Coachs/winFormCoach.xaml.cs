using Heracles.MyShowDialog;
using Heracles.Utilities;
using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace Heracles.Coachs
{
    public partial class winFormCoach : Window
    {
        Coach _coach;
        CoachImpl coachImpl;
        byte _id = 0;

        Validate validate;

        public winFormCoach()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ShowMessages();
            _coach = new Coach()
            {
                Name = txtName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                SecondLastName = txtSecondLastName.Text.Trim(),
                CI = txtCI.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };
            coachImpl = new CoachImpl();
            try
            {
                if (Inputs())
                {
                    int success = coachImpl.Insert(_coach);
                    if (success > 0)
                    {
                        winInsertDialog insertDialog = new winInsertDialog();
                        insertDialog.ShowDialog();
                    }
                    _coach = null;
                    Close();
                    winShowCoachs winShowCoachs = new winShowCoachs();
                    winShowCoachs.ShowDialog();
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
            _coach = new Coach()
            {
                Id = _id,
                Name = txtName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                SecondLastName = txtSecondLastName.Text.Trim(),
                CI = txtCI.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };
         
            coachImpl = new CoachImpl();
            try
            {
                if (Inputs())
                {
                    int success = coachImpl.Update(_coach);
                    if (success > 0)
                    {
                        winUpdateDialog updateDialog = new winUpdateDialog();
                        updateDialog.ShowDialog();
                    }
                    _coach = null;
                    Close();
                    winShowCoachs showCoachs = new winShowCoachs();
                    showCoachs.ShowDialog();
                }
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

        #region Config
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

        void ShowMessages()
        {
            txbErrorCi.Visibility = Visibility.Collapsed;
            txbErrorName.Visibility = Visibility.Collapsed;
            txbErrorLastName.Visibility = Visibility.Collapsed;
            txbErrorSecondLastName.Visibility = Visibility.Collapsed;
            txbErrorPhone.Visibility = Visibility.Collapsed;    
        }
        #endregion

        #region Validations

        private bool Inputs()
        {
            bool allValids = true;
            validate = new Validate();
            if (allValids)
            {
                if (!validate.Inputs(txtName.Text, 1))
                {
                    txbErrorName.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if (!validate.Inputs(txtLastName.Text, 1))
                {
                    txbErrorLastName.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if (!validate.Inputs(txtCI.Text, 2))
                {
                    txbErrorCi.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if (!validate.Inputs(txtPhone.Text, 3))
                {
                    txbErrorPhone.Visibility = Visibility.Visible;
                    allValids = false;
                }
                return allValids;
            }
            else
                return allValids;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.FieldTextValid(e);
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.FieldTextValid(e);
        }

        private void txtSecondLastName_KeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.FieldTextValid(e);
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.FieldNumberValid(e);
        }
        #endregion
    }
}