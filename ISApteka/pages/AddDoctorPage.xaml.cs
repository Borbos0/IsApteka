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
    /// Логика взаимодействия для AddDoctorPage.xaml
    /// </summary>
    public partial class AddDoctorPage : Page
    {
        Doctor doctor;
        public AddDoctorPage(Doctor doctor)
        {
            InitializeComponent();

            this.doctor = doctor;

            CbDoctorDegree.ItemsSource = DB.db.DoctorDegree.ToList();
            CbDoctorDegree.DisplayMemberPath = "DoctorDegreeName";
            CbDoctorDegree.SelectedValuePath = "DoctorDegreeID";

            if (doctor != null)
            {
                CheckDoctor();
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }

        }
        public void CheckDoctor()
        {
            TbName.Text = doctor.DoctorName;
            TbSecondName.Text = doctor.DoctorSecondName;
            TbSurname.Text = doctor.DoctorSurname;

            if (doctor.DoctorDegree == null)
            {
                CbDoctorDegree.SelectedIndex = 0;
            }
            else
            {
                CbDoctorDegree.SelectedItem = doctor.DoctorDegree;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbName.Text) || string.IsNullOrWhiteSpace(TbSecondName.Text)
                || string.IsNullOrWhiteSpace(TbSurname.Text) || CbDoctorDegree.SelectedItem == null)
            {
                MessageBox.Show("Заполнены не все поля");
            }
            else
            {
                try
                {
                    doctor.DoctorName = TbName.Text;
                    doctor.DoctorSecondName = TbSecondName.Text;
                    doctor.DoctorSurname = TbSurname.Text;
                    doctor.DoctorDegree = (DoctorDegree)CbDoctorDegree.SelectedItem;
                    doctor.DoctorImg = null;

                    if (doctor.DoctorID == 0)
                    {
                        DB.db.Doctor.Add(doctor);
                    }
                    DB.db.SaveChanges();

                    ChangePage.MainFrame.Navigate(new DoctorPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("Непредвиденная ошибка, проверьте правильность ввода данных");
                }
            }
        }
    }
}
