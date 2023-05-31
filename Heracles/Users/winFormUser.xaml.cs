using System;
using System.Threading;
using System.Windows;
using Heracles.MyShowDialog;
using Heracles.Utilities;
using HeraclesDAO.Logic;
using HeraclesDAO.Logic.CreateUser;
using HeraclesDAO.Models;
using HeraclesDAO.SMTP;
using System.Windows.Input;

namespace Heracles.Users
{
    public partial class winNewUser : Window
    {
        UserImpl userImpl;
        User _user;
        int _id = 0;

        #region Email
        EmailManager manager;
        Thread threadEmail;
        #endregion

        Validate validate;

        public winNewUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ShowMessages();
            manager = new EmailManager();

            _user = new User()
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                UserName = txtUserName.Text,
                Password = GenerateNewPassword(),
                Role = cmbRole.Text
            };

            userImpl = new UserImpl();
            try
            {
                if (Inputs())
                {
                    int save = userImpl.Insert(_user);
                    if (save > 0)
                    {
                        winInsertDialog winInsertDialog = new winInsertDialog();
                        winInsertDialog.ShowDialog();

                        string content = "Bienvenid@ a HERACLES!\n" +
                            "Su cargo: " + _user.Role + "\nCredenciales de acceso:\nUsuario: " +
                            _user.UserName + "\nContraseña: " + _user.Password;

                        threadEmail = new Thread(() =>
                        {
                            manager.SendEmail("eliasgonzalesec@gmail.com", _user.Email, content);
                        });
                        threadEmail.Start();

                        winSentSuccessfully winSentSuccessfully = new winSentSuccessfully();
                        winSentSuccessfully.ShowMessage("Correo enviado");
                    }
                    else
                        MessageBox.Show("No se puedo guardar el registro");

                    _user = null;
                    Close();
                    winShowUsers winShowUsers = new winShowUsers();
                    winShowUsers.ShowDialog();
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ShowMessages();
            _user = new User()
            {
                Id = _id,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                UserName = txtUserName.Text,
                Role = cmbRole.Text
            };
            userImpl = new UserImpl();
            try
            {
                if (Inputs())
                {
                    int save = userImpl.Update(_user);
                    if (save > 0)
                    {
                        winUpdateDialog winUpdateDialog = new winUpdateDialog();
                        winUpdateDialog.ShowDialog();
                    }
                    else
                        MessageBox.Show("No se actualizó el registro");
                    _user = null;
                    Close();
                    winShowUsers winShowUsers = new winShowUsers();
                    winShowUsers.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Edit(User user)
        {
            _id = user.Id;
            txtName.Text = user.Name;
            txtLastName.Text = user.LastName;   
            txtEmail.Text = user.Email;
            txtUserName.Text = user.UserName;
            cmbRole.Text = user.Role;
  
            EditControls();
            ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();   
            winShowUsers winShowUsers = new winShowUsers();
            winShowUsers.ShowDialog();
        }

        #region Config

        void EditControls()
        {
            btnSave.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            txbtitle.Text = "Editar";
        }

        void ShowMessages()
        {
            txbErrorName.Visibility = Visibility.Collapsed;
            txbErrorLastName.Visibility = Visibility.Collapsed;
            txbErrorEmail.Visibility = Visibility.Collapsed;
            txbErrorUser.Visibility = Visibility.Collapsed;
            txbErrorRole.Visibility = Visibility.Collapsed; 
        }
        #endregion

        #region Create New User
        private void btnGenerateUser_Click(object sender, RoutedEventArgs e)
        {
            GenerateNewUser(txtName.Text, txtLastName.Text, txtEmail.Text);
        }

        void GenerateNewUser(string name, string lastName, string email)
        {
            txtUserName.Text = string.Empty;
            NewUser newUser = new NewUser();
            txtUserName.Text = newUser.GenerateUserName(name, lastName, email);   
        }

        string GenerateNewPassword()
        {
            NewUser newUser = new NewUser();
            return newUser.GeneratePassword();
        }
        #endregion

        #region Validations

        private bool Inputs()
        {
            bool allValids = true;
            validate = new Validate();
            if (allValids)
            {
                if(!validate.Inputs(txtName.Text, 1))
                {
                    txbErrorName.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if(!validate.Inputs(txtLastName.Text, 1))
                {
                    txbErrorLastName.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if(!validate.Inputs(txtEmail.Text, 6))
                {
                    txbErrorEmail.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if(txtUserName.Text == string.Empty)
                {
                    txbErrorUser.Visibility = Visibility.Visible;
                    allValids = false;
                }
                if(cmbRole.SelectedItem == null)
                {
                    txbErrorRole.Visibility = Visibility.Visible;
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
        #endregion
    }
}
