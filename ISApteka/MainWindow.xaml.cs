using ISApteka.pages;
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

namespace ISApteka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Users myusers { get; set; }
        public MainWindow(Users users)
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
            ChangePage.MainFrame = MainFrame;
            myusers = users;
            Login.Text = "Вы вошли как: " + myusers.UserName+ " " + myusers.UserSecondName+ " " + myusers.UserSurname;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow exit = new AuthorizationWindow();
            exit.Show();
            Close();
        }
    }
}
