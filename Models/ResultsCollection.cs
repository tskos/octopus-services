using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OctopusServices.Models
{
    public class MyWord
    {
        public MyWord(string word)
        {
            Word = word;
        }

        [JsonRequired]
        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("count")]
        public int Count => Word.Length;
    }

    public class ResultsCollection
    {
        public ResultsCollection(List<MyWord> results)
        {
            Results = results;
        }

        [JsonProperty("results")]
        [JsonRequired]
        public List<MyWord> Results { get; set; } = new List<MyWord>();
    }
}