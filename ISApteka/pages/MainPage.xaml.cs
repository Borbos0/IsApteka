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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnStock_Click(object sender, RoutedEventArgs e)
        {
            ChangePage.MainFrame.Navigate(new StockPage());
        }

        private void BtnDoctor_Click(object sender, RoutedEventArgs e)
        {
            ChangePage.MainFrame.Navigate(new DoctorPage());
        }

        private void BtnBill_Click(object sender, RoutedEventArgs e)
        {
            ChangePage.MainFrame.Navigate(new Bill());
        }
    }
}
