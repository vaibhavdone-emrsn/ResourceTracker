using Microsoft.AspNetCore.Mvc;

namespace ResourceManager.Controllers
{
    public class LicenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
