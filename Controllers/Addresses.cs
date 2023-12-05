using KockstikSite.Database;
using KockstikSite.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace KockstikSite.Controllers
{
    public class Addresses : Controller
    {
        public IActionResult Index()
        {
            using (var context = new AppDbContext())
            {
                return View(context.Addresses.ToList());
            }
        }

        [HttpGet]
        public IActionResult Index(string title, string text)
        {
            using (var context = new AppDbContext())
            {
                ViewBag.InfoMessage = new InfoMessage(title, text);
                return View(context.Addresses.ToList());
            }
        }

        [HttpGet]
        public IActionResult SaveAddress()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveAddress(Address address)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Database.Migrate();

                    context.Addresses.Add(address);
                    context.SaveChanges();

                    return RedirectToAction("Index", "Addresses", new { title = "Выполнено", text = "Добавлен новый адрес: " + address.getFullAddress() });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Addresses", new { title = "Ошибка", text = "Ошибка добавления адреса: " + ex.ToString() });
            }
        }
    }
}
