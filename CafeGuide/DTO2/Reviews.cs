﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeGuide.DTO2
{
    class Reviews
    {
        [JsonProperty("author_name")]
        public string Author { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
