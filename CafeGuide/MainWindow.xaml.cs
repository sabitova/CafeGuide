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
        List<Cafe> cafes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            List<Cafe> cafes = new List<Cafe>();

            //using (SqlConnection connection = new SqlConnection(@"Data Source = DESKTOP-RE0AOSG; AttachDbFileName=C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TestDB1.mdf; Integrated Security = True"))
            //{
            //    connection.Open();
            //    using (var command = new SqlCommand("select * from Cafe", connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                s += string.Format("{0} {1} {2}",
            //                reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            //            }
            //        }
            //    }
            //}

            //MessageBox.Show(s);

            GetAllCafes();

        }

        void GetAllCafes()
        {
            string s = "";
            List<int> times = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                times.Add(i);
            }


            //using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-RE0AOSG; Initial Catalog = TestDB2; Integrated Security = True"))
            //{
            //    connection.Open();
            //    using (var command = new SqlCommand("select * from Address", connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                APIDirection d = new APIDirection();

            //                times.Add(d.GetDirection());
            //                //s += string.Format("{0} {1} {2}",
            //                //reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            //            }
            //        }
            //    }
            //}

            using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-RE0AOSG; Initial Catalog = TestDB2; Integrated Security = True"))
            {
                connection.Open();
                for (int i = 0; i < times.Count(); i++)
                {
                    using (var command = new SqlCommand(String.Format("UPDATE Cafe SET Time = {0} WHERE Id = {1}", times[i], i + 1), connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            //using (SqlConnection connection = new SqlConnection("Data Source = DESKTOP-RE0AOSG; Initial Catalog = TestDB2; Integrated Security = True"))
            //{
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand("UPDATE Cafe(Time) VALUES(10) WHERE Id = 1")
            //    {
            //        command.ExecuteNonQuery();
            //}
        }
    }
}
