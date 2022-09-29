using EpisodeTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodeTracker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EpisodeContext episodeContext { get; set; }

        public HomeController(ILogger<HomeController> logger, EpisodeContext episodeContext)
        {
            _logger = logger;
            this.episodeContext = episodeContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var shows = episodeContext.Shows.OrderBy(x => x.Title).ToList();
            ViewBag.IsDataAdded = false;
            if ((string)TempData["IsDataAdded"] == "yes")
            {
                ViewBag.IsDataAdded = true;
            }
            return View(shows);
        }

        [AllowAnonymous]
        [Route("/Version")]
        public IActionResult Versions()
        {
            string version = GetVersion();
            return Content(version);
        }

        [NonAction]
        private String GetVersion()
        {
            string version = "1.1.1";   // TODO: store in confie file or db

            return version;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
