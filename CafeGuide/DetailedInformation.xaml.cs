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


        public DetailedInformation(string place_id)
        {
            InitializeComponent();

            //string name= ResultList.selectedName;
            //Cafe cafe = ShowInfo(name);
            //ПЕРЕДАЙТЬ PLACE ID
            //selectedCafeInfo = APIPlaces.GetPlaceInfo(place_id);
            info = StartWindow.processingObject.GetPlaceInfo(place_id);

            textBlock_Name.Text = info[0].ToString();
            textBlock_Address.Text = info[1].ToString();
            textBlock_AverageCheck.Text = "Average Check: " + info[2].ToString();

            //textBlock_Cuisine.Text = "Cuisine: " + (info[3] as Cuisine).ToString();
            textBlock_Type.Text = info[4].ToString();
            textBlock_OpeningHours.Text = "Opening Hours: " + info[5].ToString() + "-" + info[6].ToString();
            if (info[7].ToString() == "1")
            {
                ShowImage(imageWiFi, "Resources/1024px-11wifi.png");
            }

            if (info[8] != null)
            textBlock_Website.Text = "Website: " + info[8].ToString();
            else
                textBlock_Website.Text = "Website: N/A";

            if (info[9] != null)
            textBlock_Phone.Text = "Phone number: " + info[9].ToString();
            else
                textBlock_Phone.Text = "Phone number: N/A";
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
            bi.UriSource = new Uri(path, UriKind.Relative);
            bi.EndInit();
            image.Stretch = Stretch.Fill;
            image.Source = bi;

        }
    }



}
