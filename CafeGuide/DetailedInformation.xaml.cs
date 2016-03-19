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
    /// Interaction logic for DetailedInformation.xaml
    /// </summary>
    public partial class DetailedInformation : Window
    {
        public static APIPlaces.Place selectedCafeInfo;

        public DetailedInformation()
        {
            InitializeComponent();

           string name= ResultList.selectedName;
            Cafe cafe = ShowInfo(name);
            //ПЕРЕДАЙТЬ PLACE ID
            selectedCafeInfo = APIPlaces.GetPlaceInfo("");

            var uriImageSource = new Uri(string.Format(@"https://maps.googleapis.com/maps/api/place/photo?photoreference={0}=AIzaSyAYiHyxfoRT-Z5tlEUesao7cr53lln_y7Q", selectedCafeInfo.PhotoID[0]), UriKind.RelativeOrAbsolute);
            //photo1.Source = new BitmapImage(uriImageSource);

            var uriImageSource2 = new Uri(string.Format(@"https://maps.googleapis.com/maps/api/place/photo?photoreference={0}=AIzaSyAYiHyxfoRT-Z5tlEUesao7cr53lln_y7Q", selectedCafeInfo.PhotoID[1]), UriKind.RelativeOrAbsolute);
            //photo2.Source = new BitmapImage(uriImageSource);

            textBlock_Name.Text = cafe.Name;
            textBlock_Address.Text = cafe.Address.Text;
            textBlock_AverageCheck.Text = cafe.CheckAvg.ToString()+" rub";
            textBlock_Cuisine.Text = cafe.Cuisine[0].Name;
            textBlock_Type.Text = cafe.Type.Name;
            textBlock_OpeningHours.Text = cafe.OpeningTime.TimeOfDay.ToString() + "-" + cafe.ClosingTime.TimeOfDay.ToString();
            if (cafe.WiFi == true)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri("Resources/1024px-11wifi.png", UriKind.Relative);
                bi.EndInit();
                imageWiFi.Stretch = Stretch.Fill;
                imageWiFi.Source = bi;
            }
            textBlock_Website.Text = cafe.Website;
            textBlock_Phone.Text = cafe.PhoneNumber;

            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri(string.Format(@"{0}", selectedCafeInfo.IconURL), UriKind.Relative);
            bi2.EndInit();
            imagelLogo.Stretch = Stretch.Fill;
            imagelLogo.Source = bi2;

        }

        public Cafe ShowInfo(string name)
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

        private void buttonShowMap_Click(object sender, RoutedEventArgs e)
        {
            Map map = new Map();
            map.ShowDialog();

        }

        private void buttonShowReviews_Click(object sender, RoutedEventArgs e)
        {
            Reviews reviews = new Reviews();
            reviews.ShowDialog();
        }
    }

    

}
