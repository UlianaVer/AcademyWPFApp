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
using Test7App.PageMain;
using Test7App.WindowApp;


namespace Test7App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            DataFrame.entOdb = new StudentsDB1Entities1();

            DataFrame.frameMain = FrmMain;
            FrmMain.Navigate(new PageInLogin());
        }

        private void BtnQuestion_Click(object sender, RoutedEventArgs e)
        {
            WindowHelp windowHelp = new WindowHelp();
            windowHelp.Show();
        }

        private void BtnQuestion_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Вы нажали дважды!");
        }

        private void BtnBackAllPage_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.frameMain.GoBack();
        }
    }
}
