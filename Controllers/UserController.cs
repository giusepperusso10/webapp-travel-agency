using Microsoft.AspNetCore.Mvc;

namespace NetCore_01.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
