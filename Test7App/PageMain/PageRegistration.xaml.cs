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
using Test7App.AppData;

namespace Test7App.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
            BtnCreateUser.IsEnabled = false;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.frameMain.GoBack();
        }

        private void BtnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            if (DataFrame.entOdb.User1.Count(x => x.Login == TxbLogin.Text) > 0) {
                MessageBox.Show("Пользователь с таким логином есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            User1 userModel = new User1
            {
                Login = TxbLogin.Text,
                Password = TxbPass.Text,
                IdRole = 2
            };
            DataFrame.entOdb.User1.Add(userModel);
            DataFrame.entOdb.SaveChanges();
            MessageBox.Show("Пользователь добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void PsbRePass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TxbPass.Text != PsbRePass.Password)
            {
                BtnCreateUser.IsEnabled = false;
                PsbRePass.Background = Brushes.LightCoral;
                TxbPass.Background = Brushes.LightCoral;
            }
            else {
                BtnCreateUser.IsEnabled = true;
                PsbRePass.Background = Brushes.LightGreen;
                TxbPass.Background = Brushes.LightGreen;
            }
        }
    }
}
