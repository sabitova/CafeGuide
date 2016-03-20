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
    /// Interaction logic for Reviews.xaml
    /// </summary>
    public partial class Reviews : Window
    {
        public Reviews()
        {
            InitializeComponent();

            labelName.Content = DetailedInformation.selectedCafeInfo.Name;
            
            
            for (int i=0; i < DetailedInformation.selectedCafeInfo.Reviews.Count; i++)
            {
                listBoxReviews.Items.Add("Author: " + DetailedInformation.selectedCafeInfo.Authors[i]);
                listBoxReviews.Items.Add(DetailedInformation.selectedCafeInfo.Reviews[i]);
            }


        }
    }
}
