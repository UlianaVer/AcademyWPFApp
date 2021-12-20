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


namespace Test7App.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageMainAdmin.xaml
    /// </summary>
    public partial class PageMainAdmin : Page
    {
        public PageMainAdmin()
        {
            InitializeComponent();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.frameMain.Navigate(new PageAddStudent());
        }

        private void BtnAddGrade_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.frameMain.Navigate(new PageAddGrade());
        }

        private void BtnListStudents_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.frameMain.Navigate(new PageListStudent());
        }

        private void BtnEditGrade_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.frameMain.Navigate(new PageEditGrade());
        }

        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.frameMain.Navigate(new PageDeleteStudent());
        }

        private void BtnMVC_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.frameMain.Navigate(new PageMvc());
        }
    }
}
