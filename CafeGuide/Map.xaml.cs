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
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        DBProcessing dbp = new DBProcessing();

        public Map(string place_id)
        {
            InitializeComponent();           
             

            ShowMap(dbp.GetLat(place_id), dbp.GetLong(place_id), StartWindow.location.Text);

        }

        public void ShowMap(string lat, string lon, string address)
        {
            var uriImageSource = new Uri(string.Format(@"https://maps.googleapis.com/maps/api/staticmap?center={0},{1}&zoom=15&size=400x400&markers=color:red%7Clabel:S%7C{0},{1}&markers=color:blue%7Clabel:S%7C{2}&key=%20AIzaSyDJW1i0dU5Fg0io0F2qTG4fTRdyP81b04I", lat, lon, address), UriKind.RelativeOrAbsolute);
            image.Source = new BitmapImage(uriImageSource);
        }
    }
}
