﻿using System;
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

        public StartWindow()
        {
            InitializeComponent();
          
            var uriImageSource = new Uri(@"https://maps.googleapis.com/maps/api/place/photo?photoreference={0}=AIzaSyAYiHyxfoRT-Z5tlEUesao7cr53lln_y7Q", UriKind.RelativeOrAbsolute);
            image_1.Source = new BitmapImage(uriImageSource);

        }

        private void button_Car_Click(object sender, RoutedEventArgs e)
        {
            Address location = new Address();
            location.Text = textBox_Street.Text + textBox_House.Text;

            RepoProcessing repo = new RepoProcessing();
            repo.AddEntities();

            foreach (var cafe in repo.Cafes)
            {
                cafe.TimeToGet=APIDirection.GetTime(location, cafe.Address, "driving");
            }
                       
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            
        }

        private void button_OnFoot_Click(object sender, RoutedEventArgs e)
        {

            Address location = new Address();
            location.Text = textBox_Street.Text + textBox_House.Text;

            RepoProcessing repo = new RepoProcessing();
            repo.AddEntities();

            foreach (var cafe in repo.Cafes)
            {               
                cafe.TimeToGet = APIDirection.GetTime(location, cafe.Address, "walking");
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void button_PublicTransport_Click(object sender, RoutedEventArgs e)
        {
            Address location = new Address();
            location.Text = textBox_Street.Text + textBox_House.Text;

            RepoProcessing repo = new RepoProcessing();
            repo.AddEntities();
            foreach (var cafe in repo.Cafes)
            {
                cafe.TimeToGet = APIDirection.GetTime(location, cafe.Address, "transit");
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}