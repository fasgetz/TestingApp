using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = @"Data Source=tcp:95.165.151.73, 1433;user id=fasgetz;password=sasisa; Initial Catalog=mydb;Integrated Security=True";
            string MySqlCommand = "select count(*) from Employees";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(MySqlCommand, connection);

                var item = command.ExecuteReader();

                MessageBox.Show(item.ToString());
                
            }
        }

        // Метод, который инициализирует стартовые значения
        private void StartInitialization()
        {
            
        }


        // Событие на клик CheckBox
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
