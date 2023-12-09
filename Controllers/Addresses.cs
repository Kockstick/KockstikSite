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
        public IActionResult Index(string title, string text, string type)
        {
            using (var context = new AppDbContext())
            {
                ViewBag.InfoMessage = new InfoMessage(title, text, type);
                return View(context.Addresses.ToList());
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                if (Id == 0)
                    return LogError("Пустое значение первичного ключа");

                using (var context = new AppDbContext())
                {
                    var addr = context.Addresses.Find(Id);
                    if (addr == null)
                        return LogError("Адрес не найден в базе");

                    ViewBag.Address = addr;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return LogError($"Error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult Edit(Address address)
        {
            try
            {
                if (address == null)
                    return LogError("Значение address пустое");

                using (var context = new AppDbContext())
                {
                    var addr = context.Addresses.FirstOrDefault(u => u.Id == address.Id);
                    if (addr == null)
                        return LogError("Адрес не найден в базе");

                    addr.LocalityPrefix = address.LocalityPrefix;
                    addr.LocalityName = address.LocalityName;
                    addr.StreetPrefix = address.StreetPrefix;
                    addr.StreetName = address.StreetName;
                    addr.HouseNumber = address.HouseNumber;
                    addr.HomeLetter = address.HomeLetter;
                    addr.BuildingNumber = address.BuildingNumber;
                    addr.ApartmentNumber = address.ApartmentNumber;
                    addr.RoomNumber = address.RoomNumber;
                    addr.Description = address.Description;
                    context.SaveChanges();
                }

                return LogNormal("Адрес успешно изменен");
            }
            catch (Exception ex)
            {
                return LogError($"Error: {ex}");
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (Id == 0)
                    return LogError("Пустое значение первичного ключа");

                using (var context = new AppDbContext())
                {
                    var addr = context.Addresses.FirstOrDefault(u => u.Id == Id);
                    if (addr == null)
                        return LogError("Адрес не найден в базе");

                    ViewBag.Address = addr;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return LogError($"Error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult Delete(Address address)
        {
            try
            {
                if (address == null)
                    return LogError("Значение address пустое");

                using (var context = new AppDbContext())
                {
                    context.Addresses.Remove(address);
                    context.SaveChanges();

                    return LogNormal("Адрес успешно удален");
                }
            }
            catch (Exception ex)
            {
                return LogError($"Error: {ex}");
            }
        }

        public IActionResult AddAddress() =>
            View();

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
                    context.Addresses.Add(address);
                    context.SaveChanges();

                    return LogNormal("Добавлен новый адрес: " + address.getFullAddress());
                }
            }
            catch (Exception ex)
            {
                return LogError("Ошибка добавления адреса: " + ex.ToString());
            }
        }

        private RedirectToActionResult LogError(string Text)
        {
            return RedirectToAction("Index", "Addresses", new { title = "Ошибка", text = Text, type = "error" });
        }

        private RedirectToActionResult LogNormal(string Text)
        {
            return RedirectToAction("Index", "Addresses", new { title = "Выполнено", text = Text, type = "normal" });
        }
    }
}
