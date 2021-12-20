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
    /// Логика взаимодействия для PageEditing.xaml
    /// </summary>
    public partial class PageEditing : Page
    {
        public PageEditing(Student student)
        {
            InitializeComponent();

            ClassObjStudent.Id = student.Id;

            DataGridEdit.ItemsSource = DataFrame.entOdb.Journal1.Where(x => x.IdStudent == student.Id).ToList();
            DataGridEdit.Columns[0].IsReadOnly = true;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            HistoryStudent historyStudent = new HistoryStudent()
            {
                idUser = ClassObjAdmin.Id,
                IdStudent = ClassObjStudent.Id,
                IdStatus = 1,
                DateEvent = DateTime.Now
            };
            DataFrame.entOdb.HistoryStudent.Add(historyStudent);

            DataFrame.entOdb.SaveChanges();
            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
