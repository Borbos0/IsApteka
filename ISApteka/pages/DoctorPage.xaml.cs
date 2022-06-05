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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISApteka.pages
{
    /// <summary>
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        public DoctorPage()
        {
            InitializeComponent();
            LbDoctor.ItemsSource = DB.db.Doctor.ToList();
            TbCountAll.Text = LbDoctor.Items.Count.ToString();
            BtnEdit.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;

            CbFilter.Items.Add("Все ученые степени");
            foreach (var doctorT in DB.db.DoctorDegree)
            {
                CbFilter.Items.Add(doctorT.DoctorDegreeName);
            }
            CbFilter.SelectedIndex = 0;
        }

        public void FindDoctor()
        {
            var doctor = DB.db.Doctor.Where(x => x.DoctorName.Contains(TbSearch.Text)).ToList();

            if (CbFilter.SelectedIndex > 0)
            {
                string degreeType = CbFilter.SelectedItem.ToString();
                doctor = doctor.Where(x => x.DoctorDegree.DoctorDegreeName == degreeType).ToList();
            }
            LbDoctor.ItemsSource = doctor;
            TbCount.Text = doctor.Count.ToString();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindDoctor();
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindDoctor();
        }

        private void LbDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbDoctor.SelectedItem != null)
            {
                BtnEdit.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ChangePage.MainFrame.Navigate(new AddDoctorPage(new Doctor()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var doctorSelect = LbDoctor.SelectedItem;
            ChangePage.MainFrame.Navigate(new AddDoctorPage((Doctor)doctorSelect));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить доктора?", "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    Doctor doctor = LbDoctor.SelectedItem as Doctor;
                    DB.db.Doctor.Remove(doctor);
                    DB.db.SaveChanges();
                    MessageBox.Show("Доктор удален");
                    FindDoctor();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка");
            }
        }
    }
}
