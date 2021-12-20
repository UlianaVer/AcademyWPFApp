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
using Test7App.PageAdmin;

namespace Test7App.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageInLogin.xaml
    /// </summary>
    public partial class PageInLogin : Page
    {
        public PageInLogin()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.frameMain.Navigate(new PageRegistration());
        }

        private void BtnLoginSystem_Click(object sender, RoutedEventArgs e)
        {
            try {
                User1 userModel = DataFrame.entOdb.User1.FirstOrDefault(anonym => anonym.Login==TxbLogin.Text 
                                                                        && anonym.Password==TxbPassword.Text);
                if (userModel == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Уведомление", 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Information);
                }
                else {
                    switch (userModel.IdRole) {
                        //Admin interface
                        case 1: 
                            MessageBox.Show("Администратор " + userModel.Name + ", здравствуйте!", "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                            ClassObjAdmin.Id = userModel.Id;

                            DataFrame.frameMain.Navigate(new PageMainAdmin());
                            break;

                        //User interface
                        case 2: MessageBox.Show("Пользователь " + userModel.Name + ", здравствуйте!"); 
                            break;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
