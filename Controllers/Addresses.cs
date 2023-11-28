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
        public string SaveAddress()
        {
            return "Save address get";
        }

        [HttpPost]
        public string SaveAddress(Address address)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Database.EnsureCreated();

                    context.Addresses.Add(address);
                    context.SaveChanges();

                    Debug.WriteLine("Добавлен новый адрес: " + address.getFullAddress());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ошибка добавления адреса: " + ex.ToString());
            }
            return "Save address post";
        }
    }
}
