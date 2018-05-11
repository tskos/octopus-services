using Newtonsoft.Json;

namespace OctopusServices.Models
{  
    [JsonObject]
    public class MyWord
    {
        public MyWord(string word) => this.Word = word.Trim();
        public string Word { get; set; }
        public int Count => Word.Length;
    }
}