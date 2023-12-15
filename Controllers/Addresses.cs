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
        private Log log = new Log();

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                if (Id == 0)
                    return log.LogError("Пустое значение первичного ключа");

                using (var context = new AppDbContext())
                {
                    var addr = context.Addresses.Find(Id);
                    if (addr == null)
                        return log.LogError("Адрес не найден в базе");

                    ViewBag.Address = addr;
                    ViewBag.Locations = context.Locations.ToList();
                    return View();
                }
            }
            catch (Exception ex)
            {
                return log.LogError($"Error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult Edit(Address address)
        {
            try
            {
                if (address == null)
                    return log.LogError("Значение address пустое");

                using (var context = new AppDbContext())
                {
                    /*var addr = context.Addresses.Find(address.Id);
                    if (addr == null)
                        return log.LogError("Адрес не найден в базе");

                    addr.LocationId = address.LocationId;
                    addr.StreetPrefix = address.StreetPrefix;
                    addr.StreetName = address.StreetName;
                    addr.HouseNumber = address.HouseNumber;
                    addr.HomeLetter = address.HomeLetter;
                    addr.BuildingNumber = address.BuildingNumber;
                    addr.ApartmentNumber = address.ApartmentNumber;
                    addr.RoomNumber = address.RoomNumber;
                    addr.Description = address.Description;*/

                    if (TryUpdateModelAsync(address).Result)
                    {
                        context.Entry(address).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        log.LogError("При редактировании возникла ошибка");
                    }
                }

                return log.LogNormal("Адрес успешно изменен");
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
                    var addr = context.Addresses.Find(Id);
                    if (addr == null)
                        return log.LogError("Адрес не найден в базе");

                    ViewBag.Address = addr;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return log.LogError($"Error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult Delete(Address address)
        {
            try
            {
                if (address == null)
                    return log.LogError("Значение address пустое");

                using (var context = new AppDbContext())
                {
                    context.Addresses.Remove(address);
                    context.SaveChanges();

                    return log.LogNormal("Адрес успешно удален");
                }
            }
            catch (Exception ex)
            {
                return log.LogError($"Error: {ex}");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var context = new AppDbContext();
            var locations = context.Locations.AsNoTracking().ToList();
            if (locations == null || locations.Count == 0)
                return log.LogWarning("Не найдено ни одного населенного нункта");
            return View(locations);
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Addresses.Add(address);
                    context.SaveChanges();

                    return log.LogNormal("Добавлен новый адрес: " + address.getFullAddress());
                }
            }
            catch (Exception ex)
            {
                return log.LogError("Ошибка добавления адреса: " + ex.ToString());
            }
        }
    }
}
