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
            comboBoxType.Items.Add("cafe");
            comboBoxType.Items.Add("restaurant");
            comboBoxType.Items.Add("bar");
            comboBoxType.Items.Add("coffehouse");
            comboBoxType.Items.Add("anticafe");                                   
            comboBoxType.Items.Add("fastfood");

            comboBoxCuisine.Items.Add("american");
            comboBoxCuisine.Items.Add("chinese");
            comboBoxCuisine.Items.Add("european");
            comboBoxCuisine.Items.Add("georgian");
            comboBoxCuisine.Items.Add("italian");
            comboBoxCuisine.Items.Add("japanese");
            comboBoxCuisine.Items.Add("russian");

        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {


            ResultList showResults = new ResultList();
            showResults.ShowDialog();
        }

        
    }
}
