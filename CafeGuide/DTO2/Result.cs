using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide.DTO2
{
    class Result
    {
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("photos")]
        public List<Photos> Photos { get; set; }

        [JsonProperty("place_id")]
        public string Place_ID { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("reviews")]
        public List<Reviews> Reviews { get; set; }


    }
}
