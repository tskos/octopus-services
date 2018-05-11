using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OctopusServices.Controllers
{
    [Route("[controller]/[action]")]
    public class OctopusServicesController : Controller
    {
        [HttpPost]
        public ActionResult CountWordLengths([FromBody]string body)
        {
            return new JsonResult(body);
        }
    }
}
