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
using System.Windows.Shapes;

namespace ISApteka
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        public void AuthorizationUser()
        {
            var auth = DB.db.Users.FirstOrDefault(u => u.UserLogin == TbLogin.Text);

            try
            {
                if(auth != null)
                {
                    MessageBox.Show("Выполнен успешный вход в систему");
                    MainWindow main = new MainWindow(auth);
                    main.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Пользователя с таким логином не существует");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка авторизации");
            }
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationUser();
        }
    }
}
