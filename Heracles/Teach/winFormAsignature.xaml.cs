using Heracles.MyShowDialog;
using Heracles.Utilities;
using HeraclesDAO.Logic;
using System;
using System.Windows;

namespace Heracles.Teach
{
    public partial class winFormAsignature : Window
    {
        CoachImpl coachImpl;
        LessonImpl lessonImpl;
        RoomImpl roomImpl;
        ScheduleImpl scheduleImpl;

        TeachImpl _teachImpl; 
        HeraclesDAO.Models.Teach _teach;

        int _id;

        Validate validate;

        public winFormAsignature()
        {
            InitializeComponent();
            FillCombobox();
        }

        void FillCombobox()
        {
            coachImpl = new CoachImpl();
            lessonImpl = new LessonImpl();
            roomImpl = new RoomImpl();
            scheduleImpl = new ScheduleImpl();

            cmbCoach.ItemsSource = coachImpl.GetCoachs().DefaultView;
            cmbLesson.ItemsSource = lessonImpl.Select().DefaultView;
            cmbRoom.ItemsSource = roomImpl.Select().DefaultView;
            cmbSchedule.ItemsSource = scheduleImpl.GetSchedules().DefaultView;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            winTeach winTeach = new winTeach();
            winTeach.ShowDialog();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            validate = new Validate();
            _teach = new HeraclesDAO.Models.Teach()
            {
                CoachId = short.Parse(cmbCoach.SelectedValue.ToString()),
                LessonId = short.Parse(cmbLesson.SelectedValue.ToString()),
                ScheduleId = short.Parse(cmbSchedule.SelectedValue.ToString()),
                RoomId = short.Parse(cmbRoom.SelectedValue.ToString()),
            };
            _teachImpl = new TeachImpl();
            try
            {
                if (validate.SelectionAsignments(_teach.ScheduleId, _teach.RoomId) == 1 || //registro no existe
                    validate.SelectionAsignments(_teach.ScheduleId, _teach.RoomId) == 2 ||
                    validate.SelectionAsignments(_teach.ScheduleId, _teach.RoomId) == 3)
                {
                    if (_teachImpl.Insert(_teach) > 0)
                    {
                        winInsertDialog insertDialog = new winInsertDialog();
                        insertDialog.ShowDialog();
                    }
                    _teach = null;
                    Close();
                    winTeach winTeach = new winTeach();
                    winTeach.ShowDialog();
                }
                else
                    ShowErrors("Hubo un choque, favor revise los registros e intente más tarde!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            validate = new Validate();
            _teach = new HeraclesDAO.Models.Teach()
            {
                Id = _id,
                CoachId = short.Parse(cmbCoach.SelectedValue.ToString()),
                LessonId = short.Parse(cmbLesson.SelectedValue.ToString()),
                ScheduleId = short.Parse(cmbSchedule.SelectedValue.ToString()),
                RoomId = short.Parse(cmbRoom.SelectedValue.ToString())
            };
            _teachImpl = new TeachImpl();
            try
            {
                if (validate.SelectionAsignments(_teach.ScheduleId, _teach.RoomId) == 1 || //registro no existe
                    validate.SelectionAsignments(_teach.ScheduleId, _teach.RoomId) == 2 ||
                    validate.SelectionAsignments(_teach.ScheduleId, _teach.RoomId) == 3)
                {
                    if (_teachImpl.Update(_teach) > 0)
                    {
                        winUpdateDialog winUpdateDialog = new winUpdateDialog();
                        winUpdateDialog.ShowDialog();
                    }
                    _teach = null;
                    Close();
                    winTeach winTeach = new winTeach();
                    winTeach.ShowDialog();
                }
                else
                    ShowErrors("Hubo un choque de horarios!\nFavor revise los registros e intente más tarde.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Edit(HeraclesDAO.Models.Teach teach, string coach, string schedule, string lesson, string room)
        {
            _id = teach.Id;
            cmbCoach.Text = coach;
            cmbLesson.Text = lesson;
            cmbSchedule.Text = schedule;
            cmbRoom.Text = room;
            ChangeControls();
            ShowDialog();
        }

        #region Config
        void ChangeControls()
        {
            txbtitle.Text = "Editar";
            btnSave.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
        }
        #endregion

        #region Validations
        public void ShowErrors(string error)
        {
            winValidationForms winValidationForms = new winValidationForms();
            winValidationForms.lstErrors.Visibility = Visibility.Collapsed;
            winValidationForms.txbMessage.Text = error;
            winValidationForms.txbMessage.Height = 70;
            winValidationForms.Height = 200;
            winValidationForms.txbMessage.Visibility = Visibility.Visible;
            winValidationForms.ShowDialog();
        }
        #endregion
    }
}
