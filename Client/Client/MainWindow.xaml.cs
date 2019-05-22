using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Свойства

        string SalaryParametr = string.Empty; // Параметр заработной платы
        string cb = " where Employees.Active = 1 "; // Параметр для фильтрации активных/неактивных сотрудников. Изначально только активные

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            StartInitialization();
        }

        // Метод, который инициализирует стартовые значения
        private void StartInitialization()
        {
            // Заносим в CB список параметров
            cbtype.ItemsSource = new List<string>()
            {
                "Максимальная ЗП",
                "Средняя ЗП"
            };
        }

        #region События

        // Событие на клик CheckBox
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            // Если в чек боксе стоит галочка, то передай true, иначе false
            cb = checkbox.IsChecked == true ? string.Empty : " where Employees.Active = 1 ";
        }

        private void Cbtype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            // Если выбрали первй параметр, то Max, иначе Avg            SalaryParametr = cbtype.SelectedIndex == 0 ? "Max" : "Avg";
        }


        // Событие на клик кнопки Показать сотрудников (отправляем запрос
        private void WatchEmployees_Click(object sender, RoutedEventArgs e)
        {
            // Формируем запрос
            if (SalaryParametr != string.Empty)
            {
                // Если ввели имя, то добавь к запросу
                if (EmployeeName.Text != string.Empty)
                {
                    // Если cb == string.Empty, формируем строку без второго условия. Тк. первого нет
                    if (cb == string.Empty)
                        cb = $"where Employees.Name = '{EmployeeName.Text}'";
                    else
                        cb += $"and Employees.Name = '{EmployeeName.Text}'";
                }
                // Иначе, если не ввели имя, то выведи всех
                else
                {
                    // Если в чек боксе стоит галочка, то передай true, иначе false
                    cb = checkbox.IsChecked == true ? string.Empty : " where Employees.Active = 1 ";
                }
                    

                // Формирование SqlCommand
                string MySqlCommand = "select Employees.Name as Имя_Сотрудника, " + SalaryParametr + "(Payment) as Зарплата from Employees" +
                    " left join EmployeesPlayments on EmployeesPlayments.IdEmployee = Employees.IdEmployee " +
                    cb +
                    " group by Employees.Name" +
                    " order by Зарплата desc";

                // Отправляем запрос и получаем результат
                dg.ItemsSource = new Logic().GetRows(MySqlCommand).Tables[0].DefaultView;
            }
        }

        // Событие на клик кнопки Показать всех сотрудников
        private void WatchAllEmployees_Click(object sender, RoutedEventArgs e)
        {
            // Формирование SqlCommand
            string MySqlCommand = "select Employees.IdEmployee as Айди_Сотрудника, Employees.Name as Имя_Сотрудника, Employees.Active as Сотрудник_Работает from Employees";

            // Отправляем запрос и получаем результат
            dg.ItemsSource = new Logic().GetRows(MySqlCommand).Tables[0].DefaultView;
        }

        #endregion
    }
}
