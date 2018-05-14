using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OctopusServices.Models;

namespace OctopusServices.Controllers
{
    [Route("[controller]/[action]")]
    public class OctopusServicesController : Controller
    {
        [HttpPost]
        public ActionResult CountWordLengths([FromBody]MyWordsCollection myWords)
        {
            if (!ModelState.IsValid) { return BadRequest("State is invalid!"); }
            
            var results = myWords.MyWords.Select(w => new { Word = w, Count = w.Length });

            return Ok(new { Results = results });
        }
    }
}
