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
        public IActionResult Index(CypherDecypher _cd)
        {
            if (_cd.cypherDropFrom == _cd.cypherDropTo)
            {
                ViewData["cypherFrom"] = _cd.cypherFrom;
                ViewData["cypherDropFrom"] = _cd.cypherDropFrom;
                ViewData["cypherDropTo"] = _cd.cypherDropTo;
                return View();
            }

            CypherDecypher cd = CypherFuncs.CypherSelect.Select(_cd);

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
