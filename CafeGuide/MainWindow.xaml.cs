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
using System.Data.SqlClient;

namespace CafeGuide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ConnectionString = "Data Source = DESKTOP-RE0AOSG; Initial Catalog = CafesDB; Integrated Security = True";

        public MainWindow()
        {

            InitializeComponent();

            LoadCombo("select Name from Cuisine", comboBoxCuisine);
            LoadCombo("select Name from Type", comboBoxType);
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            ResultList showResults = new ResultList();
            showResults.ShowDialog();
        }

        void LoadCombo(string sqlQueryString, ComboBox comboBox)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(sqlQueryString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox.Items.Add(reader.GetFieldValue<string>(0));
                        }
                    }
                }
            }
        }
    }
}
