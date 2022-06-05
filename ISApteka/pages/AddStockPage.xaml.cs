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
    /// Логика взаимодействия для AddStockPage.xaml
    /// </summary>
    public partial class AddStockPage : Page
    {
        Stock stock;
        public AddStockPage(Stock stock)
        {
            InitializeComponent();

            this.stock = stock;

            CbDrugType.ItemsSource = DB.db.DrugType.ToList();
            CbDrugType.DisplayMemberPath = "DrugTypeName";
            CbDrugType.SelectedValuePath = "DrugTypeID";

            CbSupplier.ItemsSource = DB.db.Supplier.ToList();
            CbSupplier.DisplayMemberPath = "SupplierName";
            CbSupplier.SelectedValuePath = "SupplierID";

            if (stock != null)
            {
                CheckStock();
            }
            else
            {
                MessageBox.Show("Выберите данные");
            }

        }
        public void CheckStock()
        {
            TbDrugName.Text = stock.DrugImage;
            TbCountInStock.Text = stock.CountInStock.ToString();
            TbStockShelf.Text = stock.StockShelf.ToString();
            TbDescription.Text = stock.Description;
            //TbDate

            if (stock.DrugType == null)
            {
                CbDrugType.SelectedIndex = 0;
            }
            else
            {
                CbDrugType.SelectedItem = stock.DrugType;
            }
            if (stock.Supplier == null)
            {
                CbSupplier.SelectedIndex = 0;
            }
            else
            {
                CbSupplier.SelectedItem = stock.Supplier;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
       
