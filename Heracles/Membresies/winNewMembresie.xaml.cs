using HeraclesDAO.Models;
using HeraclesDAO.Logic;
using System.Windows;
using System;
using Heracles.MyShowDialog;
using System.Windows.Input;
using System.Collections.Generic;
using Heracles.Utilities;

namespace Heracles.Membresies
{
    public partial class winNewMembresie : Window
    {
        Membresy _membresy;
        MembresyImpl membresyImpl;
        byte _Id = 0;

        Validate validate;

        public winNewMembresie()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string price = txtPrice.Text;
            ShowMessages();
            _membresy = new Membresy
            {
                TypeMembresy = txtType.Text.Trim()
            };
            if(txtPrice.Text == string.Empty)
                _membresy.Price = 0;
            membresyImpl = new MembresyImpl();
            try
            {
                if(Inputs())
                {
                    int success = membresyImpl.Insert(_membresy);
                    if (success > 0)
                    {
                        winInsertDialog insertDialog = new winInsertDialog();
                        insertDialog.ShowDialog();
                    }
                    _membresy = null;
                    Close();
                    ShowMembresies showMembresies = new ShowMembresies();
                    showMembresies.ShowDialog();
                }
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
            ShowMessages();
            _membresy = new Membresy()
            {
                Id = this._Id,
                TypeMembresy = txtType.Text.Trim(),
                Price = float.Parse(txtPrice.Text)
            };
            membresyImpl = new MembresyImpl();
            try
            {
                if(Inputs())
                {
                    int success = membresyImpl.Update(_membresy);
                    if (success > 0)
                    {
                        winUpdateDialog updateDialog = new winUpdateDialog();
                        updateDialog.ShowDialog();
                    }
                    this.Close();
                    ShowMembresies showMembresies = new ShowMembresies();
                    showMembresies.ShowDialog();
                }
            }
            catch (Exception ex)
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

        void ShowMessages()
        {
            txbErrorType.Visibility = Visibility.Collapsed;
        }


        #region Validations
        private bool Inputs()
        {
            bool allValids = true;
            validate = new Validate();
            if (allValids)
            {
                if(!validate.Inputs(txtType.Text, 4))
                {
                    txbErrorType.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if(!validate.Inputs(txtPrice.Text, 5))
                {
                    txbErrorPrice.Visibility = Visibility.Visible;
                    allValids = false;
                }
                return allValids;
            }
            return allValids;
        }

        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.FieldTextValid(e);
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            validate = new Validate();
            validate.FieldNumberValid(e);
        }
        #endregion
    }
}