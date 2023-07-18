using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Npgsql;
using System.IO;
using System.Text;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //static void Main(string[] args)
        //{
        //    if (args.Length == 0)
        //    {
        //        Console.WriteLine("Usage: ConsoleApp <connectionString> <query>");
        //        return;
        //    }

        //}
        public string ConnString;

        private List<long> executionTimes = new List<long>();

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
                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    sw.Stop();
                    long executionTime = sw.ElapsedMilliseconds;
                    executionTimes.Add(executionTime);

                    ResponseTextBox.Text = $"выполнено за {sw.ElapsedMilliseconds / 1000.0} секунд" + "\n";

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            ResponseTextBox.Text += reader[i].ToString() + "\t";
                        }
                        ResponseTextBox.Text += "\n";
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    sw.Stop();
                    ResponseTextBox.Text = $"Ошибка выполнения запроса: {ex.Message}";
                    connection.Close();
                }
            }

            // Запись результатов в текстовый журнал
            string logPath = "C:/Users/KasilovVD/source/repos/WpfApp2/log.txt";
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"Запрос: {query}");
                writer.WriteLine($"Время выполнения: {executionTimes.Average()} мс");
                writer.WriteLine();
            }

            // Вывод статистики
            long maxExecutionTime = executionTimes.Max();
            long minExecutionTime = executionTimes.Min();
            long medianExecutionTime = CalculateMedian(executionTimes);

            StatisticsTextBox.Text = $"Максимальное время выполнения: {maxExecutionTime} миллисекунд\n" +
                                     $"Минимальное время выполнения: {minExecutionTime} миллисекунд\n" +
                                     $"Медианное время выполнения: {medianExecutionTime} миллисекунд";
        }

        private long CalculateMedian(List<long> values)
        {
            values.Sort();
            int count = values.Count;
            if (count % 2 == 0)
            {
                return (values[count / 2 - 1] + values[count / 2]) / 2;
            }
            else
            {
                return values[count / 2];
            }
        }
    

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var Page1 = new MainWindow();
            Page1.Show();
            Close();  
           
        }

    }
}
 