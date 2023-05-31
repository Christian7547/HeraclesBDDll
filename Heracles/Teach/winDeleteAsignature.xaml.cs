using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
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
    public partial class winDeleteAsignature : Window
    {
        HeraclesDAO.Models.Teach _teach;
        TeachImpl _teachImpl;
        int _id;

        public winDeleteAsignature()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _teach = new HeraclesDAO.Models.Teach()
            {
                Id = _id
            };
            _teachImpl = new TeachImpl();
            try
            {
                _teachImpl.Delete(_teach);
                _teach = null;
                Close();
                winTeach winTeach = new winTeach();
                winTeach.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winTeach winTeach = new winTeach();
            winTeach.ShowDialog();
        }

        public void ConfirmDelete(HeraclesDAO.Models.Teach teach)
        {
            _id = teach.Id;
            ShowDialog();
        }
    }
}
