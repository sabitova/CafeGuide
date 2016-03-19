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
        public DetailedInformation()
        {
            InitializeComponent();

           string name= ResultList.selectedName;
            Cafe cafe = ShowInfo(name);

            textBlock_Name.Text = cafe.Name;
            textBlock_Address.Text = cafe.Address.Text;
            textBlock_AverageCheck.Text = cafe.CheckAvg.ToString()+" rub";
            textBlock_Cuisine.Text = cafe.Cuisine[0].Name;
            textBlock_Type.Text = cafe.Type.Name;
            textBlock_OpeningHours.Text = cafe.OpeningTime.TimeOfDay.ToString() + "-" + cafe.ClosingTime.TimeOfDay.ToString();
            if (cafe.WiFi == true)
                textBlock_Wi_Fi.Text = "Wi-Fi";
            textBlock_Website.Text = cafe.Website;
            textBlock_Phone.Text = cafe.PhoneNumber;

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
