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
    /// Логика взаимодействия для BillPage.xaml
    /// </summary>
    public partial class BillPage : Page
    {
        public BillPage()
        {
            InitializeComponent();
            LbBill.ItemsSource = DB.db.Bill.ToList();
            TbCountAll.Text = LbBill.Items.Count.ToString();
            BtnEdit.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;

            CbFilter.Items.Add("Все препараты");
            foreach (var billT in DB.db.Bill)
            {
                CbFilter.Items.Add(billT.ShortClientName);
            }
            CbFilter.SelectedIndex = 0;

            CbSort.Items.Add("Сортировка");
            CbSort.Items.Add("По возрастанию");
            CbSort.Items.Add("По убыванию");

            CbSort.SelectedIndex = 0;
        }

        public void FindBill()
        {
            var bill = DB.db.Bill.Where(x => x.Description.Contains(TbSearch.Text)).ToList();

            LbBill.ItemsSource = bill;
            TbCount.Text = bill.Count.ToString();
            int summ = 0;
            foreach(var el in bill)
            {
                summ += Decimal.ToInt32(el.Price);
            }
            TbPrice.Text = summ.ToString();

            switch (CbSort.SelectedIndex)
            {
                case 1:
                    bill = bill.OrderBy(s => s.Price).ToList();
                    break;
                case 2:
                    bill = bill.OrderByDescending(s => s.Price).ToList();
                    break;
            }

            if (CbFilter.SelectedIndex > 0)
            {
                string drugName = CbFilter.SelectedItem.ToString();
                bill = bill.Where(x => x.Stock.DrugName == drugName).ToList();
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindBill();
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindBill();
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindBill();
        }

        private void LbBill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbBill.SelectedItem != null)
            {
                BtnEdit.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ChangePage.MainFrame.Navigate(new AddBillPage(new Bill()));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var billSelect = LbBill.SelectedItem;
            ChangePage.MainFrame.Navigate(new AddBillPage((Bill)billSelect));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить квитанцию об оплате?", "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    Bill bill = LbBill.SelectedItem as Bill;
                    DB.db.Bill.Remove(bill);
                    DB.db.SaveChanges();
                    MessageBox.Show("Квитанция об оплате удален");
                    FindBill();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка");
            }
        }
    }
}
