using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide.DTO2
{
    class Response
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}
