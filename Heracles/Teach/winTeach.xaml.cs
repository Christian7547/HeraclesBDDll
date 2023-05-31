using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Heracles.Teach
{
    public partial class winTeach : Window
    {
        TeachImpl teachImpl;

        HeraclesDAO.Models.Teach _teach;

        public winTeach()
        {
            InitializeComponent();
            teachImpl = new TeachImpl();
            dtgData.ItemsSource = teachImpl.Select().DefaultView;
            dtgData.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnNewRecord_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winFormAsignature formAsignature = new winFormAsignature();
            formAsignature.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string coach = ((DataRowView)dtgData.SelectedItem).Row["Coach"].ToString();
            string lesson = ((DataRowView)dtgData.SelectedItem).Row["Lesson"].ToString();
            string schedule = ((DataRowView)dtgData.SelectedItem).Row["Schedule"].ToString();
            string room = ((DataRowView)dtgData.SelectedItem).Row["Room"].ToString();
            _teach = new HeraclesDAO.Models.Teach()
            {
                Id = int.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString())
            };
            Close();
            winFormAsignature formAsignature = new winFormAsignature();
            formAsignature.Edit(_teach, coach, schedule, lesson, room);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _teach = new HeraclesDAO.Models.Teach()
            {
                Id = int.Parse(((DataRowView)dtgData.SelectedItem).Row["ID"].ToString())
            };
            Close();
            winDeleteAsignature winDeleteAsignature = new winDeleteAsignature();
            winDeleteAsignature.ConfirmDelete(_teach);
        }
    }
}
