using EpisodeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodeTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EpisodeContext episodeContext { get; set; }

        public HomeController(ILogger<HomeController> logger, EpisodeContext episodeContext)
        {
            _logger = logger;
            this.episodeContext = episodeContext;
        }

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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
