using System.Windows;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Heracles.Utilities
{
    public partial class winValidationForms : Window
    {
        public winValidationForms()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void PrintErrors(List<ValidationFailure> errors)
        {
            foreach (var item in errors)
            {
                lstErrors.Items.Add(item);
            }
            ShowDialog();
        }
    }
}
