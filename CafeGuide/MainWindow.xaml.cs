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
using System.Data.Entity;
using System.Data.SqlClient;

namespace CafeGuide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();      
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";

            using (SqlConnection connection = new SqlConnection(@"Data Source = DESKTOP-RE0AOSG; AttachDbFileName=C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TestDB1.mdf; Integrated Security = True"))
            {
                connection.Open();
                using (var command = new SqlCommand("select * from Cafe", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            s += string.Format("{0} {1} {2}",
                            reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                        }
                    }
                }
            }

            MessageBox.Show(s);
        }
    }
}
