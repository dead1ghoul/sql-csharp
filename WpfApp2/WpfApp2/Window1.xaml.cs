using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Shapes;
using Npgsql;
using WpfApp2;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string ConnString;
      
        public Window1()
        {
            InitializeComponent();
        }

        private void ExecuteQuery_Click(object sender, RoutedEventArgs e)
        {
            string query = QueryTextBox.Text;

            string connString = ConnString;

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {

                var sw = new Stopwatch();
                sw.Start();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                try
                {
                    command.ExecuteNonQuery();
                    sw.Stop();
                    ResponseTextBox.Text = $"выполнено за {sw.ElapsedMilliseconds / 1000} секунд";
                }
                catch
                {
                    sw.Stop();
                    ResponseTextBox.Text = $"невалидный запрос";
                }
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
 