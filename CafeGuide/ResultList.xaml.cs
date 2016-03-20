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
        public List<Cafe> suitableCafes;
        public static DataTable dt = new DataTable();

        public ResultList(string type, string cuisine, int avgCheck, int time, bool wifi)
        {
            InitializeComponent();

            try
            {
                StartWindow.processingObject.GetSuitableCafes(time, type, cuisine, avgCheck, wifi);

                if (dt.Rows.Count == 0)
                    MessageBox.Show("Nothing found :{");

                dataGrid_Results.ItemsSource = dt.DefaultView;
                dataGrid_Results.ColumnWidth = 164;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGrid_Results_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try {
                DataRowView rowview = dataGrid_Results.SelectedItem as DataRowView;
                string name = rowview.Row[0].ToString();
                string placeid = StartWindow.processingObject.GetPlaceId(name);
                DetailedInformation info = new DetailedInformation(placeid);

                info.ShowDialog();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
