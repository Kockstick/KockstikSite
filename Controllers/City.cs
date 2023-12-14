using KockstikSite.Database;
using KockstikSite.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KockstikSite.Controllers
{
    public class City : Controller
    {
        private Log log = new Log();

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Locations.Add(location);
                    context.SaveChanges();

                    return log.LogNormal("Добавлен населенный пункт: " + location.Prefix + "." + location.Name);
                }
            }
            catch (Exception ex)
            {
                return log.LogError("Ошибка добавления адреса: " + ex.ToString());
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                if (Id == 0)
                    return log.LogError("Пустое значение первичного ключа");

                using (var context = new AppDbContext())
                {
                    var location = context.Locations.Find(Id);
                    if (location == null)
                        return log.LogError("Адрес не найден в базе");

                    ViewBag.Location = location;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return log.LogError($"Error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult Edit(Location location)
        {
            try
            {
                if (location == null)
                    return log.LogError("Значение location пустое");

                using (var context = new AppDbContext())
                {
                    /*
                    var loc = context.Locations.Find(location.Id);
                    if (loc == null)
                        return log.LogError("Населенный пункт не найден в базе");

                    loc.Prefix = location.Prefix;
                    loc.Name = location.Name;
                    */

                    if (TryUpdateModelAsync(location).Result)
                    {
                        context.Entry(location).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        log.LogError("При редактировании возникла ошибка");
                    }
                }

                return log.LogNormal("Населенный пункт успешно изменен");
            }
            catch (Exception ex)
            {
                return log.LogError($"Error: {ex}");
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (Id == 0)
                    return log.LogError("Пустое значение первичного ключа");

                using (var context = new AppDbContext())
                {
                    var location = context.Locations.Find(Id);
                    if (location == null)
                        return log.LogError("Населенный пункт не найден в базе");

                    ViewBag.Location = location;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return log.LogError($"Error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult Delete(Location location)
        {
            try
            {
                if (location == null)
                    return log.LogError("Значение location пустое");

                using (var context = new AppDbContext())
                {
                    var loc = context.Locations.Find(location.Id);
                    if (loc == null)
                        return log.LogError("Населенный пункт не найден в базе");
                    loc.Addresses = context.Addresses.Where(a => a.LocationId == loc.Id).ToList();

                    context.Addresses.RemoveRange(loc.Addresses);
                    context.Locations.Remove(loc);
                    context.SaveChanges();

                    return log.LogNormal("Населенный пункт успешно удален");
                }
            }
            catch (Exception ex)
            {
                return log.LogError($"Error: {ex}");
            }
        }
    }
}
