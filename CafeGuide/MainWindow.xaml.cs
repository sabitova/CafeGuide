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
        public static string ConnectionString = "Data Source = DESKTOP-tmq0bt1; Initial Catalog = CafesDB; Integrated Security = True";

        public MainWindow()
        {
            InitializeComponent();

            // Filling comboboxes with data from the DB
            LoadCombo("select Name from Cuisine", comboBoxCuisine);
            LoadCombo("select Name from Type", comboBoxType);
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResultList showResults = new ResultList(comboBoxType.Text, comboBoxCuisine.Text,
                    textBoxAverageCheck.Text == "" ? 0 : Convert.ToInt32(textBoxAverageCheck.Text),
                    textBoxTime.Text == "" ? 0 : Convert.ToInt32(textBoxTime.Text),
                    checkBoxWiFi.IsChecked.Value);

                showResults.ShowDialog();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.processingObject.FindCafeByName(textBoxName.Text);
        }
    }
}
