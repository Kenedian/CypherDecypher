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
            string cypherFrom = cd.cypherFrom;

            string cypherDropFrom = cd.cypherDropFrom;
            string cypherDropTo = cd.cypherDropTo;

            if(cypherDropFrom == cypherDropTo)
            {
                ViewData["cypherFrom"] = cypherFrom;
                ViewData["cypherDropFrom"] = cypherDropFrom;
                ViewData["cypherDropTo"] = cypherDropTo;
                return View();
            }

            if (cypherFrom != null)
            {
                if (cypherDropFrom != "Normal" && cypherDropTo != "Normal")
                {
                    string cypherMethod = cypherDropFrom + "ToNormal";
                    cd.InvokeMethod(cypherMethod, new List<object> { cypherFrom });
                    cypherMethod = "NormalTo" + cypherDropTo;
                    cd.InvokeMethod(cypherMethod, new List<object> { cd.cypherTo });
                }
                else
                {
                    string cypherMethod = cypherDropFrom + "To" + cypherDropTo;
                    cd.InvokeMethod(cypherMethod, new List<object> { cypherFrom });
                }
                //Result
                
            }
            ViewData["cypherResult"] = cd.cypherTo;
            ViewData["cypherFrom"] = cypherFrom;
            ViewData["cypherDropFrom"] = cypherDropFrom;
            ViewData["cypherDropTo"] = cypherDropTo;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
