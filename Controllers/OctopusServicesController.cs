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
        public ActionResult CountWordLengths([FromBody]IEnumerable<MyWord> words)
        {
            if ((words == null) || !words.Any() || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var results = words.OrderBy(w => w.Word);

            return Ok(new { Results = results });
        }
    }
}
