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
        public static string ConnectionString = "Data Source = DESKTOP-re0aosg; Initial Catalog = CafesDB; Integrated Security = True";

        public MainWindow()
        {
            // Filling comboboxes with data from the DB

            try
            {
                InitializeComponent();

                LoadCombo("select Name from Cuisine", comboBoxCuisine);
                LoadCombo("select Name from Type", comboBoxType);

            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private async void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            await StartWindow.slowTask;
            Cursor = Cursors.Arrow;
            try
            {
                ResultList showResults = new ResultList(comboBoxType.Text, comboBoxCuisine.Text,
                    textBoxAverageCheck.Text == "" ? 0 : Convert.ToInt32(textBoxAverageCheck.Text),
                    textBoxTime.Text == "" ? 0 : Convert.ToInt32(textBoxTime.Text),
                    checkBoxWiFi.IsChecked.Value);

                showResults.ShowDialog();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadCombo(string sqlQueryString, ComboBox comboBox)
        {
            // try {
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
            // }

            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message, "Error");
            // }
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            await StartWindow.slowTask;
            Cursor = Cursors.Arrow;

            if (textBoxName.Text == "")
                MessageBox.Show("Please enter a proper name");
            else
                StartWindow.processingObject.FindCafeByName(textBoxName.Text);
        }
    }
}
