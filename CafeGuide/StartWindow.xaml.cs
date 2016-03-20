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

        //public static IProcessing processingObject = new RepoProcessing();
      public static IProcessing processingObject = new DBProcessing();

        public static Address location = new Address();
        public static Task slowTask = null;

        public StartWindow()
        {
            InitializeComponent();
            if (processingObject is RepoProcessing)
                (processingObject as RepoProcessing).AddEntities();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = ((Button)sender).Content.ToString();

            location.Text = "Moscow," + textBox_Street.Text + "," + textBox_House.Text;

            switch (buttonText)
            {
                case "Car":
                    //slowTask = Task.Factory.StartNew(() => processingObject.GetTimeForAllCafes(location, "driving"));
                    slowTask = Task.Factory.StartNew(() => SlowDude());
                    break;
                case "On Foot":
                    slowTask = Task.Factory.StartNew(() => processingObject.GetTimeForAllCafes(location, "walking"));
                    break;
                case "Public Transport":
                    slowTask = Task.Factory.StartNew(() => processingObject.GetTimeForAllCafes(location, "transit"));
                    break;
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        // удалить!
        private void SlowDude()
        {
            Thread.Sleep(5000);
            MessageBox.Show("Ta-dam! Here I am!");
        }

    }
}
