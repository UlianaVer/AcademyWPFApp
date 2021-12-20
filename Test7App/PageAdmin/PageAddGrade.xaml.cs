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
    /// Логика взаимодействия для PageAddGrade.xaml
    /// </summary>
    public partial class PageAddGrade : Page
    {
        public PageAddGrade()
        {
            InitializeComponent();
            CmbNameGroup.SelectedValuePath = "Id";
            CmbNameGroup.DisplayMemberPath= "Name";
            CmbNameGroup.ItemsSource = DataFrame.entOdb.NameGroup.ToList();

            CmbSelectDisp.SelectedValuePath = "Id";
            CmbSelectDisp.DisplayMemberPath = "Name";
            CmbSelectDisp.ItemsSource = DataFrame.entOdb.Discipline.ToList();

            CmbSelectStudent.SelectedValuePath = "Id";
            CmbSelectStudent.DisplayMemberPath = "Name";
        }

        private void BtnAddGrade_Click(object sender, RoutedEventArgs e)
        {
            Journal1 journalObj = new Journal1()
            {
                Evaluation = TxbGrade.Text,
                Student = CmbSelectStudent.SelectedItem as Student,
                Discipline = CmbSelectDisp.SelectedItem as Discipline,
                NameGroup = CmbNameGroup.SelectedItem as NameGroup
            };
            DataFrame.entOdb.Journal1.Add(journalObj);
            DataFrame.entOdb.SaveChanges();
            MessageBox.Show("Оценка добавлена!", "Уведомление", MessageBoxButton.OK,
                            MessageBoxImage.Information);
            DataFrame.frameMain.GoBack();
        }

        private void CmbNameGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectStudent = Convert.ToInt32(CmbNameGroup.SelectedValue);
            CmbSelectStudent.ItemsSource =
                DataFrame.entOdb.Student.Where(x => x.IdNameGroup == SelectStudent).ToList();
        }
    }
}
