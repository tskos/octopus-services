using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OctopusServices.Models
{
    
    public class MyWordsCollection
    {
        public MyWordsCollection() {}

        [JsonProperty("myWords")]
        [JsonRequired]
        public List<string> MyWords { get; set; } = new List<string>();
    }
}