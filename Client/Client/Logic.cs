using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{

    /// <summary>
    /// Класс, который представляет логику работы программы с БД
    /// </summary>

    class Logic
    {
        // Строка подключения
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=mydb;Integrated Security=True";

        public DataSet GetRows(string MySqlCommand)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                SqlDataAdapter adapter = new SqlDataAdapter(MySqlCommand, connection);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                connection.Close();
                return ds;                
            }

        }
    }
}
