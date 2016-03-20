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

        public string placeID;

        public DetailedInformation(string place_id)
        {
            InitializeComponent();

            placeID = place_id;

            selectedCafeInfo = APIPlaces.GetPlaceInfo(place_id);
            info = StartWindow.processingObject.GetPlaceInfo(place_id);

            ShowImage(photo1, string.Format(@"https://maps.googleapis.com/maps/api/place/photo?photoreference={0}=AIzaSyCVQZ77qOQBuvlNskkPKYaBU63_l-5B0Us", selectedCafeInfo.PhotoID[0]));
            ShowImage(photo2, string.Format(@"https://maps.googleapis.com/maps/api/place/photo?photoreference={0}=AAIzaSyCVQZ77qOQBuvlNskkPKYaBU63_l-5B0Us", selectedCafeInfo.PhotoID[1]));
            ShowImage(photo3, string.Format(@"https://maps.googleapis.com/maps/api/place/photo?photoreference={0}=AIzaSyCVQZ77qOQBuvlNskkPKYaBU63_l-5B0Us", selectedCafeInfo.PhotoID[2]));

            textBlock_Name.Text = "Name: " + info[0].ToString();
            textBlock_Address.Text = "Address: " + info[1].ToString();
            textBlock_AverageCheck.Text = "Average Check: " + info[2].ToString();
            
            textBlock_Type.Text = "Type: " + info[4].ToString();
            textBlock_OpeningHours.Text = "Opening Hours: " + info[5].ToString() + "-" + info[6].ToString();
            if (info[7].ToString() == "1")
            {
                ShowImage(imageWiFi, "Resources/1024px-11wifi.png");
            }
            textBlock_Website.Text = "Website: " + info[8] ?? ToString();
            textBlock_Phone.Text = "Phone number: " + info[9] ?? ToString();


        }

        private void buttonShowMap_Click(object sender, RoutedEventArgs e)
        {
            Map map = new Map(placeID);
            map.ShowDialog();
        }

        private void buttonShowReviews_Click(object sender, RoutedEventArgs e)
        {
            Reviews reviews = new Reviews();
            reviews.ShowDialog();
        }

        public static void ShowImage(Image image, string path)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            bi.EndInit();
            image.Stretch = Stretch.Fill;
            image.Source = bi;

        }
    }



}
