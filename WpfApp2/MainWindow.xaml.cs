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
using Npgsql;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public string ConnectionString { get; set; }
        public NpgsqlConnectionStringBuilder builder;

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            builder = new NpgsqlConnectionStringBuilder();
            builder.Host = DatabaseAddressTextBox.Text;
            builder.Port = 5432;
            builder.Username = UsernameTextBox.Text;
            builder.Password = PasswordBox.Password;
            builder.Database = "postgres";
            string connString = builder.ConnectionString;
            builder.MaxPoolSize = 10;//count of flows

            //using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            //{
            //    connection.Open();
            //    // выполнение операций с подключением
            //    connection.Close();
            //}

            ConnectionString = connString;

            var Page2 = new Window1(); //create your new form.
            Page2.Show();


            //string query = "SELECT COUNT(*) FROM employees";
            //NpgsqlCommand command = new NpgsqlCommand(query, connection);
            //int activeConnections = (int)command.ExecuteScalar();
        }


        //private void QueryButton_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
