using FluentValidation;
using FluentValidation.Results;
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
            txtName.PreviewKeyDown += txtName_PreviewKeyDown;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            HiddenMessages();
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
                if (Inputs(_coach))
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
            HiddenMessages();
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
                if (Inputs(_coach))
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

        void HiddenMessages()
        {
            txbErrorCi.Visibility = Visibility.Collapsed;
            txbErrorName.Visibility = Visibility.Collapsed;
            txbErrorLastName.Visibility = Visibility.Collapsed;
            txbErrorSecondLastName.Visibility = Visibility.Collapsed;
            txbErrorPhone.Visibility = Visibility.Collapsed;    
        }

        void ShowMessages()
        {
            txbErrorCi.Visibility = Visibility.Visible;
            txbErrorName.Visibility = Visibility.Visible;
            txbErrorLastName.Visibility = Visibility.Visible;
            txbErrorSecondLastName.Visibility = Visibility.Visible;
            txbErrorPhone.Visibility = Visibility.Visible;
        }
        #endregion

        #region Validations

        private bool Inputs(Coach coach)
        {
            CoachValidation validationRules = new CoachValidation();
            ValidationResult result = validationRules.Validate(coach);
            if (!result.IsValid)
            {
                winValidationForms validationForms = new winValidationForms();
                validationForms.PrintErrors(result.Errors);
                return result.IsValid;
            }
            return result.IsValid;
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

        private void txtName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.LockedSpaceKey(e, txtName.Text);
        }

        private void txtLastName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.LockedSpaceKey(e, txtLastName.Text);
        }

        private void txtSecondLastName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.LockedSpaceKey(e, txtSecondLastName.Text);
        }

        private void txtCI_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.LockedSpaceKey(e, txtCI.Text);
        }

        private void txtPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.LockedSpaceKey(e, txtPhone.Text);
        }
        #endregion
    }
}