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
            TbDrugName.Text = stock.DrugName;
            TbCountInStock.Text = stock.CountInStock.ToString();
            TbStockShelf.Text = stock.StockShelf.ToString();
            TbDescription.Text = stock.Description;
            DpDate.Text = stock.DateEnd;

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
            if (string.IsNullOrWhiteSpace(TbCountInStock.Text) || string.IsNullOrWhiteSpace(TbDrugName.Text)
                || string.IsNullOrWhiteSpace(TbDescription.Text) || string.IsNullOrWhiteSpace(TbStockShelf.Text)
                || CbDrugType.SelectedItem == null || CbSupplier.SelectedItem == null)
            {
                MessageBox.Show("Заполнены не все поля");
            }
            else
            {
                try
                {
                    stock.DrugName = TbDrugName.Text;
                    stock.Description = TbDescription.Text;
                    stock.CountInStock = int.Parse(TbCountInStock.Text);
                    stock.StockShelf = int.Parse(TbStockShelf.Text);
                    stock.DrugType = (DrugType)CbDrugType.SelectedItem;
                    stock.Supplier = (Supplier)CbSupplier.SelectedItem;
                    stock.DrugImage = null;
                    stock.DateEnd = DpDate.Text;

                    if(stock.StockID == 0)
                    {
                        DB.db.Stock.Add(stock);
                    }
                    DB.db.SaveChanges();

                    ChangePage.MainFrame.Navigate(new StockPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("Непредвиденная ошибка, проверьте правильность ввода данных");
                }
            }
        }
    }
}
       
