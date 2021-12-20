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

namespace Test7App.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageEditGrade.xaml
    /// </summary>
    public partial class PageEditGrade : Page
    {
        public PageEditGrade()
        {
            InitializeComponent();
            CmdNameGroup.SelectedValuePath = "Id";
            CmdNameGroup.DisplayMemberPath = "Name";
            CmdNameGroup.ItemsSource = DataFrame.entOdb.NameGroup.ToList();

            DataGridInfo.IsReadOnly = true;
        }

        private void CmdNameGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectGroupStudent = Convert.ToInt32(CmdNameGroup.SelectedValue);
            DataGridInfo.ItemsSource = DataFrame.entOdb.Student.Where(x => x.IdNameGroup == SelectGroupStudent).ToList();
            DataGridInfo.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DataFrame.frameMain.Navigate(new PageEditing((sender as Button).DataContext as Student));
        }
    }
}
