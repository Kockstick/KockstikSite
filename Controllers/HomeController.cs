using KockstikSite.Database;
using KockstikSite.Database.Models;
using KockstikSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KockstikSite.Controllers
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
            using (var context = new AppDbContext())
            {
                ViewBag.Cities = context.Locations.ToList();
                ViewBag.Addresses = context.Addresses.ToList();
                return View();
            }
        }

        [HttpGet]
        public IActionResult Index(string title, string text, string type)
        {
            using (var context = new AppDbContext())
            {
                ViewBag.InfoMessage = new InfoMessage(title, text, type);
                ViewBag.Cities = context.Locations.ToList();
                ViewBag.Addresses = context.Addresses.ToList();
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Analytics()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}