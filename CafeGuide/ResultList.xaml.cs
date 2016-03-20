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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace CafeGuide
{
    /// <summary>
    /// Interaction logic for ResultList.xaml
    /// </summary>
    public partial class ResultList : Window
    {
        public string ConnectionString = "Data Source = DESKTOP-RE0AOSG; Initial Catalog = CafesDB; Integrated Security = True";

        IProcessing processingObj = new DBProcessing();
        public List<Cafe> suitableCafes;
        public Item selectedItem;
        public static string selectedName;
        public static DataTable dt = new DataTable();

        public string Type { get; set; }
        public string Cuisine { get; set; }
        public int AvgCheck { get; set; }
        public int Time { get; set; }
        public bool WiFi { get; set; }

        public ResultList(string type, string cuisine, int avgCheck, int time, bool wifi)
        {
            //Type = type;
            //Cuisine = cuisine;
            //AvgCheck = avgCheck;
            //Time = time;
            //WiFi = wifi;

            InitializeComponent();

            processingObj.GetSuitableCafes(time, type, cuisine, avgCheck, wifi);
            dataGrid_Results.ItemsSource = dt.DefaultView;
        }

        public class Item
        { 
            public string Name { get; set; }
            public int Time { get; set; }
            public double AvgCheck { get; set; }
        }

        public ResultList()
        {
            InitializeComponent();

            //string query = QueryString();

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Open();
            //    using (var command = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            //        {
            //            DataTable dt = new DataTable();
            //            adapter.Fill(dt);
            //            dataGrid_Results.DataContext = dt.DefaultView;
            //        }
            //    }
            //}

            //DataGridTextColumn c1 = new DataGridTextColumn();
            //c1.Header = "Name";
            //c1.Binding = new Binding("Name");
            //dataGrid_Results.Columns.Add(c1);

            //DataGridTextColumn c2 = new DataGridTextColumn();
            //c2.Header = "Time";
            ////c2.Binding = new Binding("Time");
            //dataGrid_Results.Columns.Add(c2);

            //DataGridTextColumn c3 = new DataGridTextColumn();
            //c3.Header = "Average Check";
            //c3.Binding = new Binding("CheckAvg");
            //dataGrid_Results.Columns.Add(c3);

            //RepoProcessing obj = new RepoProcessing();
            //obj.AddEntities();
            ////suitableCafes = obj.GetSuitableCafes(60);
            ////foreach (var c in suitableCafes)
            ////{
            ////    dataGrid_Results.Items.Add(new Item { Name = c.Name, AvgCheck = c.CheckAvg});
            ////}


            //dataGrid_Results.Columns[0].Width = 300;
            //dataGrid_Results.Columns[1].Width = 100;
            //dataGrid_Results.Columns[2].Width = 100;

        }

        private void Size()
        {
            double columnWidth = 0;
            foreach (DataGridColumn dgc in this.dataGrid_Results.Columns)
                columnWidth += dgc.ActualWidth;

            this.dataGrid_Results.Columns[2].Width = this.dataGrid_Results.ActualWidth - columnWidth + this.dataGrid_Results.Columns[2].ActualWidth - 8;
        }

        private void dataGrid_Results_Loaded(object sender, RoutedEventArgs e)
        {
            Size();
        }

        private void ataGrid_Results_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Size();
        }
        private void dataGrid_Results_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = dataGrid_Results.SelectedItem as Item;
            selectedName = selectedItem.Name;
            DetailedInformation info = new DetailedInformation();
            info.ShowDialog();
        }

        private void dataGrid_Results_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = dataGrid_Results.SelectedItem as Item;
            selectedName = selectedItem.Name;
            DetailedInformation info = new DetailedInformation();
            info.ShowDialog();
        }
    }
}
