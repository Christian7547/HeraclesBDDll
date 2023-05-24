using System;
using System.Windows;
using System.Windows.Threading;

namespace Heracles.MyShowDialog
{
    public partial class winSentSuccessfully : Window
    {
        private DispatcherTimer timer;
        private int counter = 0;
        private int durationInSeconds = 3;

        public winSentSuccessfully()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        public void ShowMessage(string message)
        {
            txbMessage.Text = message;
            Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs eventArgs)
        {
            counter++;
            if(counter >= durationInSeconds)
            {
                timer.Stop();
                Close();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
