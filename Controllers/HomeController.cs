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
            return RedirectToAction("Index", "Addresses");
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