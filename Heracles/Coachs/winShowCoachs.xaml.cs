using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System.Data;
using System.Windows;

namespace Heracles.Coachs
{
    public partial class winShowCoachs : Window
    {
        Coach _coach = null;
        CoachImpl coachImpl;

        public winShowCoachs()
        {
            InitializeComponent();
            Select();
        }

        void Select()
        {
            coachImpl = new CoachImpl();
            dtgData.ItemsSource = coachImpl.Select().DefaultView;
            dtgData.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void btnNewCoach_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            winFormCoach winFormCoach = new winFormCoach();
            winFormCoach.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            _coach = new Coach()
            {
                Id = byte.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString()),
                Name = ((DataRowView)dtgData.SelectedItem).Row["Name"].ToString(),
                LastName = ((DataRowView)dtgData.SelectedItem).Row["LastName"].ToString(),
                SecondLastName = ((DataRowView)dtgData.SelectedItem).Row["SecondLastName"].ToString(),
                CI = ((DataRowView)dtgData.SelectedItem).Row["CI"].ToString(),
                Phone = ((DataRowView)dtgData.SelectedItem).Row["Phone"].ToString()
            };
            this.Close();
            winFormCoach formCoach = new winFormCoach();
            formCoach.Edit(_coach);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _coach = new Coach()
            {
                Id = byte.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString()),
                Name = ((DataRowView)dtgData.SelectedItem).Row["Name"].ToString(),
                LastName = ((DataRowView)dtgData.SelectedItem).Row["LastName"].ToString(),
                SecondLastName = ((DataRowView)dtgData.SelectedItem).Row["SecondLastName"].ToString(),
                CI = ((DataRowView)dtgData.SelectedItem).Row["CI"].ToString(),
                Phone = ((DataRowView)dtgData.SelectedItem).Row["Phone"].ToString()
            };
            this.Close();
            winConfirmDelete confirmDelete = new winConfirmDelete();
            confirmDelete.Confirm(_coach);
        }
    }
}