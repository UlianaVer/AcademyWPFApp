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
    /// Логика взаимодействия для PageDeleteStudent.xaml
    /// </summary>
    public partial class PageDeleteStudent : Page
    {
        public PageDeleteStudent()
        {
            InitializeComponent();

            CmdNameGroup.SelectedValuePath = "Id";
            CmdNameGroup.DisplayMemberPath = "Name";
            CmdNameGroup.ItemsSource = DataFrame.entOdb.NameGroup.ToList();

            DataGridList.IsReadOnly = true;
        }

        private void BtmSearch_Click(object sender, RoutedEventArgs e)
        {
            int SelectGroupStudent = Convert.ToInt32(CmdNameGroup.SelectedValue);
            DataGridList.ItemsSource = DataFrame.entOdb.Student.Where(x => x.IdNameGroup == SelectGroupStudent).ToList();
            DataGridList.SelectedIndex = 0;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridList.SelectedItems.Count > 0) {

                for (int i = 0; i < DataGridList.SelectedItems.Count; i++) {
                    Student studentObj = DataGridList.SelectedItems[i] as Student;
                    DataFrame.entOdb.Student.Remove(studentObj);
                }
                DataFrame.entOdb.SaveChanges();
                MessageBox.Show("Пользователь успешно удален!",
                                "Уведомление", MessageBoxButton.OK,
                                MessageBoxImage.Asterisk);

                int SelectGroupStudent = Convert.ToInt32(CmdNameGroup.SelectedValue);
                DataGridList.ItemsSource = DataFrame.entOdb.Student.Where(x => x.IdNameGroup == SelectGroupStudent).ToList();
                DataGridList.SelectedIndex = 0;
            }
            else {
                MessageBox.Show("В таблице нет данных для удаления!", 
                                "Уведомление", MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}
