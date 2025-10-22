using Microsoft.AspNetCore.Mvc;

namespace ResourceManager.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
