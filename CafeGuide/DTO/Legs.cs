using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide.DTO
{
    class Legs
    {
        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("distance")]
        public Distance Distance { get; set; }
    }
}
