using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CafeGuide.DTO;

namespace CafeGuide
{
    public static class APIDirection
    {
        public static int GetTime(Address from, Address to, string mode)
        {
            WebClient client = new WebClient();

            string query = string.Format("https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1},{2}&mode={3}&key=AIzaSyAYiHyxfoRT-Z5tlEUesao7cr53lln_y7Q", from.Text, to.Lat, to.Long, mode);
            var result = client.DownloadString(query);
            var data = JsonConvert.DeserializeObject<Response>(result);
            return data.Routes[0].Legs[0].Duration.Value;                  
        }
    }
}
