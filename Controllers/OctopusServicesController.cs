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
        [HttpGet]
        public ActionResult CountWordLengths()
        {
            return new JsonResult("test");
        }
    }
}
