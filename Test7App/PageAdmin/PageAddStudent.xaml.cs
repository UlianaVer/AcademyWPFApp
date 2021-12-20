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
    /// Логика взаимодействия для PageAddStudent.xaml
    /// </summary>
    public partial class PageAddStudent : Page
    {
        public PageAddStudent()
        {
            InitializeComponent();

            CmbSpecial.SelectedValuePath = "Id";
            CmbSpecial.DisplayMemberPath = "Name";
            CmbSpecial.ItemsSource = DataFrame.entOdb.Special.ToList();        
                                                                               
            CmbYearAdd.SelectedValuePath = "Id";                               
            CmbYearAdd.DisplayMemberPath = "Year";                             
            CmbYearAdd.ItemsSource = DataFrame.entOdb.YearAdd.ToList();        
                                                                               
            CmbFormTime.SelectedValuePath = "Id";                              
            CmbFormTime.DisplayMemberPath = "Name";                            
            CmbFormTime.ItemsSource = DataFrame.entOdb.FormTime.ToList();      
                                                                               
            CmbNameGroup.SelectedValuePath = "Id";                             
            CmbNameGroup.DisplayMemberPath = "Name";                           
            CmbNameGroup.ItemsSource = DataFrame.entOdb.NameGroup.ToList();    

        }                                                                      
                                                                               
        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Student stObj = new Student
            {
                Name = TxbName.Text,
                Special = CmbSpecial.SelectedItem as Special,
                YearAdd = CmbYearAdd.SelectedItem as YearAdd,
                FormTime = CmbFormTime.SelectedItem as FormTime,
                NameGroup = CmbNameGroup.SelectedItem as NameGroup
            };

            DataFrame.entOdb.Student.Add(stObj);
            DataFrame.entOdb.SaveChanges();
            MessageBox.Show("Студент добавлен! Сейчас вы перейдете в Главное меню.", 
                            "Уведомление", MessageBoxButton.OK,
                            MessageBoxImage.Information);

            DataFrame.frameMain.GoBack();
        }
    }
}
