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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public event Action<string> CarIsClicked;
        public event Action<string> OnFootIsClicked;
        public event Action<string> TransportIsClicked;

        public StartWindow()
        {
            InitializeComponent();
        }

        private void button_Car_Click(object sender, RoutedEventArgs e)
        {
            if (CarIsClicked != null)
                CarIsClicked("driving");
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            
        }

        private void button_OnFoot_Click(object sender, RoutedEventArgs e)
        {
            if (OnFootIsClicked != null)
                OnFootIsClicked("walking");
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void button_PublicTransport_Click(object sender, RoutedEventArgs e)
        {
            if (TransportIsClicked != null)
                TransportIsClicked("transit");
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}
