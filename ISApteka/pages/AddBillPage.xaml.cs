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
    /// Логика взаимодействия для AddBillPage.xaml
    /// </summary>
    public partial class AddBillPage : Page
    {
        Bill bill;
        public AddBillPage(Bill bill)
        {
            InitializeComponent();

            this.bill = bill;

            CbDoctor.ItemsSource = DB.db.Doctor.ToList();
            CbDoctor.DisplayMemberPath = "DoctorName";
            //CbDoctor.DisplayMemberPath = "DoctorSecondName";
            //CbDoctor.DisplayMemberPath = "DoctorSurname";
            CbDoctor.SelectedValuePath = "DoctorID";

            CbDrugName.ItemsSource = DB.db.Stock.ToList();
            CbDrugName.DisplayMemberPath = "DrugName";
            CbDrugName.SelectedValuePath = "StockID";

            if (bill != null)
            {
                CheckBill();
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }
        }
        public void CheckBill()
        {
            TbClientName.Text = bill.ShortClientName;
            TbDescription.Text = bill.Description;
            TbPrice.Text = bill.Price.ToString();
            DpDate.Text = bill.DateBeg;

            if (bill.Doctor == null)
            {
                CbDoctor.SelectedIndex = 0;
            }
            else
            {
                CbDoctor.SelectedItem = bill.Doctor;
            }
            if (bill.Stock == null)
            {
                CbDrugName.SelectedIndex = 0;
            }
            else
            {
                CbDrugName.SelectedItem = bill.Stock;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbClientName.Text) || string.IsNullOrWhiteSpace(TbDescription.Text)
                || string.IsNullOrWhiteSpace(TbPrice.Text) || CbDoctor.SelectedItem == null
                || CbDrugName.SelectedItem == null)
            {
                MessageBox.Show("Заполнены не все поля");
            }
            else
            {
                try
                {
                    bill.ShortClientName = TbClientName.Text;
                    bill.Description = TbDescription.Text;
                    bill.Price = int.Parse(TbPrice.Text);
                    bill.Stock = (Stock)CbDrugName.SelectedItem;
                    bill.Doctor = (Doctor)CbDoctor.SelectedItem;
                    bill.DateBeg = DpDate.Text;
                    bill.BillImage = null;

                    if (bill.BillID == 0)
                    {
                        DB.db.Bill.Add(bill);
                    }
                    DB.db.SaveChanges();

                    ChangePage.MainFrame.Navigate(new BillPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("Непредвиденная ошибка, проверьте правильность ввода данных");
                }
            }
        }
    }
}
