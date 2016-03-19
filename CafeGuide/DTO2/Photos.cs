using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide.DTO2
{
    class Photos
    {
        [JsonProperty("photo_reference")]
        public string PhotoReference { get; set; }
    }
}
