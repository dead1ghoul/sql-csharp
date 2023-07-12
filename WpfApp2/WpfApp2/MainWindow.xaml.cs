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

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();
            builder.Host = DatabaseAddressTextBox.Text;
            builder.Port = 5432;
            builder.Username = UsernameTextBox.Text;
            builder.Password = PasswordBox.Password;
            builder.Database = "postgres";
            string connString = builder.ConnectionString;
            builder.MaxPoolSize = 10;//count of flows
            
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();
            string query = "SELECT COUNT(*) FROM employees";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            //int activeConnections = (int)command.ExecuteScalar();
            connection.Close();
        }

        private void SelectAllUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InsertUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
