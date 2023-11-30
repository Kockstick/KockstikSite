using KockstikSite.Database;
using KockstikSite.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KockstikSite.Controllers
{
    public class Addresses : Controller
    {
        [HttpGet]
        public IActionResult SaveAddress(string title, string text)
        {
            ViewBag.InfoMessage = new InfoMessage(title, text);
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public IActionResult SaveAddress(Address address)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Database.EnsureCreated();

                    context.Addresses.Add(address);
                    context.SaveChanges();

                    return RedirectToAction("SaveAddress", "Addresses", new { title = "Выполнено", text = "Добавлен новый адрес: " + address.getFullAddress() });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("SaveAddress", "Addresses", new { title = "Ошибка", text = "Ошибка добавления адреса: " + ex.ToString() });
            }
        }
    }
}
