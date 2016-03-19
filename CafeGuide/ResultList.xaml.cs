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

namespace CafeGuide
{
    /// <summary>
    /// Interaction logic for ResultList.xaml
    /// </summary>
    public partial class ResultList : Window
    {
      
       public List<Cafe> suitableCafes;
        public Item selectedItem;
       public static string selectedName;

        public class Item
        { 
            public string Name { get; set; }
            public DateTime Time { get; set; }
            public double AvgCheck { get; set; }
        }

        public ResultList()
        {
            InitializeComponent();
            
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Name";
            c1.Binding = new Binding("Name");
            dataGrid_Results.Columns.Add(c1);

            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Time";
            //c2.Binding = new Binding("Time");
            dataGrid_Results.Columns.Add(c2);

            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Average Check";
            c3.Binding = new Binding("CheckAvg");
            dataGrid_Results.Columns.Add(c3);

            RepoProcessing obj = new RepoProcessing();
            obj.AddEntities();
            //suitableCafes = obj.GetSuitableCafes(60);
            //foreach (var c in suitableCafes)
            //{
            //    dataGrid_Results.Items.Add(new Item { Name = c.Name, AvgCheck = c.CheckAvg});
            //}

        }

        private void dataGrid_Results_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            selectedItem = dataGrid_Results.SelectedItem as Item;
            selectedName = selectedItem.Name;
            DetailedInformation info = new DetailedInformation();
            info.ShowDialog();

        }

    }
}
