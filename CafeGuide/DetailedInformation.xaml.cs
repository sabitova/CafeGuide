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
            listBox_Features.Items.Add("Address");
            listBox_Features.Items.Add("Type");
            listBox_Features.Items.Add("Cuisine");
            listBox_Features.Items.Add("Opening Hours");
            listBox_Features.Items.Add("Average Check");
            listBox_Features.Items.Add("Wi-Fi");
            listBox_Features.Items.Add("Website");
            listBox_Features.Items.Add("Phone Number");

            listBox_Info.Items.Add(cafe.Address.Text);
            listBox_Info.Items.Add(cafe.Type.Name);
            listBox_Info.Items.Add(cafe.Cuisine[0].Name);
            listBox_Info.Items.Add(cafe.OpeningTime.Hour +":"+ cafe.OpeningTime.Minute+ "-"+ cafe.ClosingTime.Hour+"-" + cafe.ClosingTime.Minute);
            if (cafe.WiFi == true)
                listBox_Info.Items.Add("Yes");
            else listBox_Info.Items.Add("No");
            listBox_Info.Items.Add(cafe.Website);
            listBox_Info.Items.Add(cafe.PhoneNumber);




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
    }

    

}
