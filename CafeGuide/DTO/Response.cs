using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide.DTO
{
    class Response
    {
        [JsonProperty("routes")]
        public Routes Routes { get; set; }
    }
}
