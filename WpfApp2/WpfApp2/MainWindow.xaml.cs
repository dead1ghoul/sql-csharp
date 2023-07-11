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
            string host = DatabaseAddressTextBox.Text;
            string port = PortTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string db_name = "postgres";
            string connString = $"Host={host};Port={port};Username={username};Password={password};Database={db_name};";
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {

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
            NewForm newForm = new NewForm();
            newForm.Show();
        }

        //private void QueryButton_Click(Object sender, EventArgs e)
        //{
        //    NewForm myForm = new NewForm();
        //    myForm.Show();
        //}

    }
}
