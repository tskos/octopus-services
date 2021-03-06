﻿using System;
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
        [ProducesResponseType(typeof(ResultsCollection), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult CountWordLengths([FromBody]MyWordsCollection myWords)
        {
            if (!ModelState.IsValid) { return BadRequest("State is invalid!"); }

            var results = myWords.MyWords.Select(w => new MyWord(w)).ToList();

            return Ok(new ResultsCollection(results));
        }
    }
}
