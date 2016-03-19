using CafeGuide.DTO2;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide
{
   public class APIPlaces
    {
        public class Place
        {
            public string IconURL { get; set; }
            public List<string> PhotoID { get; set; }
            public string Rating { get; set; }
            public List<string> Authors { get; set; }
            public List<string> Reviews { get; set; }
        }

        public static Place GetPlaceInfo (string placeID)
        {
            WebClient client = new WebClient();

            string query = string.Format("https://maps.googleapis.com/maps/api/place/details/json?placeid=ChIJN1t_tDeuEmsRUsoyG83frY4&key=AIzaSyDJW1i0dU5Fg0io0F2qTG4fTRdyP81b04I", placeID);
            var result = client.DownloadString(query);
            var data = JsonConvert.DeserializeObject<Response>(result);

            List<string> photos = new List<string>();
            foreach (var photo in data.Result.Photos)
            {
                photos.Add(photo.PhotoReference);
            }

            List<string> reviews = new List<string>();
            List<string> authors = new List<string>();
            for (int i=0; i<data.Result.Reviews.Count-1; i++ )
            {
                reviews.Add(data.Result.Reviews[i].Text);
                authors.Add(data.Result.Reviews[i].Author);

            }

            return new Place {IconURL=data.Result.Icon, PhotoID = photos, Rating = data.Result.Rating, Authors = authors, Reviews=reviews};           
        }  
    }
}
