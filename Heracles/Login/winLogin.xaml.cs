using System;
using System.Data;
using System.Windows;
using Heracles.Menus;
using Heracles.Users.UpdateProfile;
using HeraclesDAO.Logic;
using HeraclesDAO.Models.Session;

namespace Heracles.Login
{
    public partial class winLogin : Window
    {
        UserImpl userImpl;

        public winLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SignIn(txtTUserName.Text, txtPassword.Password);
        }

        void SignIn(string userName, string password)
        {
            try
            {
                userImpl = new UserImpl();
                DataTable userTable = userImpl.Login(userName, password);
                if(userTable.Rows.Count > 0)
                {
                    SessionClass.SessionId = int.Parse(userTable.Rows[0][0].ToString());    
                    SessionClass.SessionUserName = userTable.Rows[0][1].ToString();
                    SessionClass.SessionRole = userTable.Rows[0][2].ToString();
                    SessionClass.SessionEmail = userTable.Rows[0][3].ToString();
                    int firstSession = int.Parse(userTable.Rows[0][4].ToString());

                    if(firstSession == 0)
                    {
                        ClearTextBox();
                        this.Visibility = Visibility.Hidden;
                        winChangePassword winChangePassword = new winChangePassword();
                        winChangePassword.ShowDialog();
                        userImpl.FirstSession();
                        this.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.Visibility = Visibility.Hidden;
                        switch (SessionClass.SessionRole)
                        {
                            case "Administrador":
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.ShowDialog();
                                break;
                            case "Recepcionista":
                                winMenuReceptionist menuReceptionist = new winMenuReceptionist();
                                menuReceptionist.ShowDialog();
                                break;
                            case "Coach":
                                winMenuCoach menuCoach = new winMenuCoach();
                                menuCoach.ShowDialog();
                                break;
                        }
                    }
                }
                else
                {
                    ClearTextBox();
                    winIncorrectLogin winIncorrectLogin = new winIncorrectLogin();
                    winIncorrectLogin.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        void ClearTextBox()
        {
            txtTUserName.Text = string.Empty;
            txtPassword.Password = string.Empty;
        }
    }
}
