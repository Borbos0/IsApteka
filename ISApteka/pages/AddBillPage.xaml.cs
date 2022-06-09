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
using Word = Microsoft.Office.Interop.Word;

namespace ISApteka.pages
{
    /// <summary>
    /// Логика взаимодействия для AddBillPage.xaml
    /// </summary>
    public partial class AddBillPage : Page
    {
        Bill bill;
        private readonly string TemplateFileName = @"C:\Users\User\Desktop\ISApteka\TemplateForBill.docx";
        public AddBillPage(Bill bill)
        {
            InitializeComponent();

            this.bill = bill;

            BtnPrint.Visibility = Visibility.Hidden;
            if (bill.BillID != 0)
            {
                BtnPrint.Visibility = Visibility.Visible;
            }

            CbDoctor.ItemsSource = DB.db.Doctor.ToList();
            CbDoctor.SelectedValuePath = "DoctorID";

            CbDrugName.ItemsSource = DB.db.Stock.ToList();
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
            TbClientName.Text = bill.ClientName;
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
                    bill.ClientName = TbClientName.Text;
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

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var client = TbClientName.Text;
            var doctor = (Doctor)CbDoctor.SelectedItem;
            var drug = (Stock)CbDrugName.SelectedItem;
            var description = TbDescription.Text;
            var price = TbPrice.Text.ToString();
            var price1 = TbPrice.Text.ToString();
            var price2 = TbPrice.Text.ToString();
            var datebeg = DpDate.Text;
            var datebeg1 = DpDate.Text;

            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordStub("{client}", client, wordDocument);
                ReplaceWordStub("{doctor}", doctor + "", wordDocument);
                ReplaceWordStub("{drug}", drug + "", wordDocument);
                ReplaceWordStub("{description}", description, wordDocument);
                ReplaceWordStub("{price}", price + "", wordDocument);
                ReplaceWordStub("{price1}", price1 + "", wordDocument);
                ReplaceWordStub("{price2}", price2 + "", wordDocument);
                ReplaceWordStub("{date}", datebeg, wordDocument);
                ReplaceWordStub("{date1}", datebeg1, wordDocument);

                wordDocument.SaveAs(@"C:\Users\User\Desktop\ISApteka\TemplateForBillAnswer.docx");
                wordApp.Visible = true;
            }
            catch
            {
                MessageBox.Show("Непредвиденная ошибка");
            }
        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
    }
}
