using Microsoft.AspNetCore.Mvc;

namespace KockstikSite
{
    public class Log : Controller
    {
        public RedirectToActionResult LogError(string Text)
        {
            return RedirectToAction("Index", "Home", new { title = "Ошибка", text = Text, type = "error" });
        }

        public RedirectToActionResult LogNormal(string Text)
        {
            return RedirectToAction("Index", "Home", new { title = "Выполнено", text = Text, type = "normal" });
        }

        public RedirectToActionResult LogWarning(string Text)
        {
            return RedirectToAction("Index", "Home", new { title = "Внимание", text = Text, type = "warning" });
        }
    }
}
