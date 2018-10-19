using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab08_LINQInManhattan.Classes
{
    public class Feature
    {
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Properties")]
        public Properties Properties { get; set; }
    }
}
