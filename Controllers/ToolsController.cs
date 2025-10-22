using Microsoft.AspNetCore.Mvc;

namespace ResourceManager.Controllers
{
    public class ToolsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
