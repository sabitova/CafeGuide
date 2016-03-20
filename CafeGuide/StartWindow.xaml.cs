using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        //Uncomment one of the lines depending on what you want to work with (Repo or DB)

       // public static IProcessing processingObject = new RepoProcessing();
        public static IProcessing processingObject = new DBProcessing();

        public static Address location = new Address();
        public static Task slowTask = null;

        public StartWindow()
        {
            MessageBox.Show("Hello! This is an application that will help you to choose where to have a meal. Please enter your coordinates (just the NAME of the street and the number" +
                            " of the building you are currently in - nothing more). Then you will proceed to choosing cafes by the name or by parameters. Good Luck!", "CafeGuide");
            InitializeComponent();
            if (processingObject is RepoProcessing)
                (processingObject as RepoProcessing).AddEntities();

            if (processingObject is DBProcessing)
                (processingObject as DBProcessing).ClearTimeColumn();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = ((Button)sender).Content.ToString();

            if (textBox_Street.Text == "" || textBox_House.Text == "")
            {
                MessageBox.Show("Please enter a street name and a house number", "Error");
                return;
            }

            location.Text = "Moscow," + textBox_Street.Text.Replace(' ', ',') + "," + textBox_House.Text.Replace(' ', ',');

            try
            { 
                switch (buttonText)
                {
                    case "By car":
                        //slowTask = Task.Factory.StartNew(() => processingObject.GetTimeForAllCafes(location, "driving"));
                        slowTask = Task.Factory.StartNew(() => SlowDude());
                        break;
                    case "On foot":
                        slowTask = Task.Factory.StartNew(() => processingObject.GetTimeForAllCafes(location, "walking"));
                        break;
                    case "By public transport":
                        slowTask = Task.Factory.StartNew(() => processingObject.GetTimeForAllCafes(location, "transit"));
                        break;
                }

                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // удалить!
        private void SlowDude()
        {
            Thread.Sleep(5000);
            MessageBox.Show("Ta-dam! Here I am!");
        }

    }
}
