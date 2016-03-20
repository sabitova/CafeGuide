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
using System.Collections;

namespace CafeGuide
{
    /// <summary>
    /// Interaction logic for DetailedInformation.xaml
    /// </summary>
    public partial class DetailedInformation : Window
    {
        public static APIPlaces.Place selectedCafeInfo;
        public ArrayList info = new ArrayList();
        DBProcessing dbp = new DBProcessing();

        public DetailedInformation(string place_id)
        {
            InitializeComponent();

            //string name= ResultList.selectedName;
            //Cafe cafe = ShowInfo(name);

            selectedCafeInfo = APIPlaces.GetPlaceInfo(place_id);
            info = dbp.GetPlaceInfo(place_id);

            textBlock_Name.Text = "Name: " + info[0].ToString();
            textBlock_Address.Text = "Address: " + info[1].ToString();
            textBlock_AverageCheck.Text = "Average Check: " + info[2].ToString();
            textBlock_Cuisine.Text = "Cuisine: " + info[3].ToString();
            textBlock_Type.Text = "Type: " + info[4].ToString();
            textBlock_OpeningHours.Text = "Opening Hours: " + info[5].ToString() + "-" + info[6].ToString();
            if (info[7].ToString() == "1")
            {
                ShowImage(imageWiFi, "Resources/1024px-11wifi.png");
            }
            textBlock_Website.Text = "Website: " + info[8].ToString();
            textBlock_Phone.Text = "Phone number: " + info[9].ToString();

            ShowMap(dbp.GetLat(place_id), dbp.GetLong(place_id), StartWindow.location.Text);

            //textBlock_Name.Text = cafe.Name;
            //textBlock_Address.Text = cafe.Address.Text;
            //textBlock_AverageCheck.Text = cafe.CheckAvg.ToString()+" rub";
            //textBlock_Cuisine.Text = cafe.Cuisine[0].Name;
            //textBlock_Type.Text = cafe.Type.Name;
            //textBlock_OpeningHours.Text = cafe.OpeningTime.TimeOfDay.ToString() + "-" + cafe.ClosingTime.TimeOfDay.ToString();
            //if (cafe.WiFi == true)
            //{
            //    ShowImage(imageWiFi, "Resources/1024px-11wifi.png");                            
            //}
            //textBlock_Website.Text = cafe.Website;
            //textBlock_Phone.Text = cafe.PhoneNumber;

        }

        public static Cafe ShowInfo(string name)
        {
            ResultList result = new ResultList();
            List<Cafe> suitableCafes = result.suitableCafes;
            Cafe selectedCafe = new Cafe();
            foreach (var c in suitableCafes)
            {
                if (c.Name == name)
                {
                    selectedCafe = c;
                    break;
                }
            }
            return selectedCafe;

        }
     
        private void buttonShowReviews_Click(object sender, RoutedEventArgs e)
        {
            Reviews reviews = new Reviews();
            reviews.ShowDialog();
        }

        public void ShowImage(Image image, string path)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(path, UriKind.Relative);
            bi.EndInit();
            image.Stretch = Stretch.Fill;
            image.Source = bi;

        }
        public void ShowMap(string lat, string lon, string address)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(string.Format(@"https://maps.googleapis.com/maps/api/staticmap?center={0},{1}&zoom=13&size=400x400&markers=color:red%7Clabel:S%7C{0},{1}&markers=color:blue%7Clabel:S%7C{2}&key=%20AIzaSyDJW1i0dU5Fg0io0F2qTG4fTRdyP81b04I", lat, lon, address), UriKind.RelativeOrAbsolute);
            bi.EndInit();
            imageMap.Stretch = Stretch.Fill;
            imageMap.Source = bi;
            
        }
    }



}
