using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace OctopusServices.Controllers
{
    [Route("[controller]/[action]")]
    public class OctopusServicesController : Controller
    {
        [HttpPost]
        public ActionResult CountWordLengths([FromBody]JObject body)
        {
            var myWordsKey = "myWords";

            var results = body[myWordsKey]
                .OrderBy(w => (string)w)
                .Select(w => new { Word = (string)w, Count = ((string)w).Length });

            return new JsonResult(new { Results = results });
        }
    }
}
