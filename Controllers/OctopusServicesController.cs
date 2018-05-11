using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OctopusServices.Controllers
{
    [JsonObject]
    public class MyWord
    {
        public MyWord(string word) => this.Word = word.Trim();
        public string Word { get; set; }
        public int Count => Word.Length;
    }

    [Route("[controller]/[action]")]
    public class OctopusServicesController : Controller
    {
        [HttpPost]
        public ActionResult CountWordLengths([FromBody]IEnumerable<string> words)
        {
            if ((words == null) || !words.Any() || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var results = words.OrderBy(w => w).Select(w => new MyWord(w));

            return Ok(new { Results = results });
        }
    }
}
