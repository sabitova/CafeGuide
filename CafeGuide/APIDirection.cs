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
    class APIDirection
    {
        public int GetDirection()
        {
        WebClient client = new WebClient();

        string query = string.Format("https://maps.googleapis.com/maps/api/directions/json?origin={0},{1}&destination={2},{3}&key=AIzaSyAYiHyxfoRT-Z5tlEUesao7cr53lln_y7Q", "55.763789", "37.634681", "55.973491856606415", "37.16025675924686");
        var result = client.DownloadString(query);
        var data = JsonConvert.DeserializeObject<Response>(result);

        return int.Parse(data.Routes[0].Legs[0].Duration.Value);
    }
    }
}
