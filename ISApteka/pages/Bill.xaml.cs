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
    /// Логика взаимодействия для Bill.xaml
    /// </summary>
    public partial class Bill : Page
    {
        public Bill()
        {
            InitializeComponent();
            LbBill.ItemsSource = DB.db.Bill.ToList();
            TbCountAll.Text = LbBill.Items.Count.ToString();

            CbFilter.Items.Add("Все Все");
            CbFilter.SelectedIndex = 0;
            CbSort.Items.Add("Сорт Сорт");
            CbSort.SelectedIndex = 0;
        }

        public void FindBill()
        {
            var bill = DB.db.Bill.Where(x => x.ClientName.Contains(TbSearch.Text)).ToList();

            LbBill.ItemsSource = bill;
            TbCount.Text = bill.Count.ToString();
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
            FindBill();
        }
    }
}
