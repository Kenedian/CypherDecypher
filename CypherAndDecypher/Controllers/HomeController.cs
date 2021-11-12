using CypherAndDecypher.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CypherAndDecypher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["cypherResult"] = "";
            ViewData["cypherFrom"] = "";
            ViewData["cypherDropFrom"] = "Normal";
            ViewData["cypherDropTo"] = "Morse";
 
            return View();
        }
        [HttpPost]
        public IActionResult Index(CypherDecypher cd)
        {
            if(cd.cypherDropFrom == cd.cypherDropTo)
            {
                ViewData["cypherFrom"] = cd.cypherFrom;
                ViewData["cypherDropFrom"] = cd.cypherDropFrom;
                ViewData["cypherDropTo"] = cd.cypherDropTo;
                return View();
            }

            if (cd.cypherDropTo == "Normal")
            {
                cd.cypherTo = cd.cyphers[cd.cypherDropFrom].Decypher(cd.cypherFrom);
            }
            else if(cd.cypherDropFrom == "Normal")
            {
                cd.cypherTo = cd.cyphers[cd.cypherDropTo].Cypher(cd.cypherFrom);
            }
            else
            {
                string tempCypher;
                tempCypher = cd.cyphers[cd.cypherDropFrom].Decypher(cd.cypherFrom);
                cd.cypherTo = cd.cyphers[cd.cypherDropTo].Cypher(tempCypher);
            }

            ViewData["cypherResult"] = cd.cypherTo;
            ViewData["cypherFrom"] = cd.cypherFrom;
            ViewData["cypherDropFrom"] = cd.cypherDropFrom;
            ViewData["cypherDropTo"] = cd.cypherDropTo;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
