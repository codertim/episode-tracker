using EpisodeTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace EpisodeTracker.Controllers
{
    public class ShowController : Controller
    {
        private EpisodeContext context { get; set; }
        public ShowController(EpisodeContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Show());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var show = context.Shows.Find(id);
            return View(show);
        }

        [HttpPost]
        public IActionResult Edit(Show show)
        {
            if (ModelState.IsValid)
            {
                if (show.ShowId == 0)
                {
                    context.Shows.Add(show);
                }
                else
                {
                    context.Shows.Update(show);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (show.ShowId == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                return View(show);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var show = context.Shows.Find(id);
            return View(show);
        }

        [HttpPost]
        public IActionResult Delete(Show show)
        {
            context.Shows.Remove(show);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
