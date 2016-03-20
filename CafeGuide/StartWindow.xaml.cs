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
        IProcessing RP = new RepoProcessing();
        IProcessing DBP = new DBProcessing();

        public static Address location = new Address();

        public StartWindow()
        {
            InitializeComponent();
          
        }

        private void button_Car_Click(object sender, RoutedEventArgs e)
        {       
            location.Text = "Moscow," + textBox_Street.Text + "," + textBox_House.Text;
         
            //RP.AddEntities();
            //foreach (var cafe in RP.Cafes)
            //{
            //    cafe.TimeToGet = APIDirection.GetTime(location, cafe.Address, "driving");
            //}
           
            //DBP.GetTimeForAllCafes(location, "driving");
                             
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();           
        }

        private void button_OnFoot_Click(object sender, RoutedEventArgs e)
        {
            location.Text = "Moscow," + textBox_Street.Text + "," + textBox_House.Text;

            //RP.AddEntities();
            //foreach (var cafe in RP.Cafes)
            //{
            //    cafe.TimeToGet = APIDirection.GetTime(location, cafe.Address, "driving");
            //}

            DBP.GetTimeForAllCafes(location, "walking");
                             
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog(); 
        }

        private void button_PublicTransport_Click(object sender, RoutedEventArgs e)
        {
            location.Text = "Moscow," + textBox_Street.Text + "," + textBox_House.Text;

            //RP.AddEntities();
            //foreach (var cafe in RP.Cafes)
            //{
            //    cafe.TimeToGet = APIDirection.GetTime(location, cafe.Address, "driving");
            //}

            DBP.GetTimeForAllCafes(location, "transit");

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void buttonClicked(string text)
        {

        }
    }
}
