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
    /// Логика взаимодействия для StockPage.xaml
    /// </summary>
    public partial class StockPage : Page
    {
        public StockPage()
        {
            InitializeComponent();
            LbStock.ItemsSource = DB.db.Stock.ToList();
            TbCountAll.Text = LbStock.Items.Count.ToString();
            BtnEdit.Visibility = Visibility.Hidden;
            BtnDelete.Visibility = Visibility.Hidden;

            CbFilter.Items.Add("Все препараты");
            foreach (var stockT in DB.db.DrugType)
            {
                CbFilter.Items.Add(stockT.DrugTypeName);
            }
            CbFilter.SelectedIndex = 0;

            CbSort.Items.Add("Сортировка");
            CbSort.Items.Add("По возрастанию");
            CbSort.Items.Add("По убыванию");

            CbSort.SelectedIndex = 0;
        }

        public void FindStock()
        {
            var stock = DB.db.Stock.Where(x => x.DrugName.Contains(TbSearch.Text)).ToList();

            switch (CbSort.SelectedIndex)
            {
                case 1:
                    stock = stock.OrderBy(s => s.CountInStock).ToList();
                    break;
                case 2:
                    stock = stock.OrderByDescending(s => s.CountInStock).ToList();
                    break;
            }

            if (CbFilter.SelectedIndex > 0)
            {
                string drugType = CbFilter.SelectedItem.ToString();
                stock = stock.Where(x => x.DrugType.DrugTypeName == drugType).ToList();
            }
            LbStock.ItemsSource = stock;
            TbCount.Text = stock.Count.ToString();

            int summ = 0;
            foreach (var el in stock)
            {
                summ += Decimal.ToInt32(el.CountInStock);
            }
            TbDrugType.Text = summ.ToString();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindStock();
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindStock();
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindStock();
        }

        private void LbStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbStock.SelectedItem != null)
            {
                BtnEdit.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var drugSelect = LbStock.SelectedItem;
            ChangePage.MainFrame.Navigate(new AddStockPage((Stock)drugSelect));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ChangePage.MainFrame.Navigate(new AddStockPage(new Stock()));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить препарат?", "Внимание", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    Stock stock = LbStock.SelectedItem as Stock;
                    DB.db.Stock.Remove(stock);
                    DB.db.SaveChanges();
                    MessageBox.Show("Препарат удален");
                    FindStock();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка");
            }
        }
    }
}
