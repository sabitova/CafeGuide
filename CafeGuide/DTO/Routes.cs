using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide.DTO
{
    class Routes
    {
        [JsonProperty("legs")]
        public Legs Legs { get; set; }
    }
}
