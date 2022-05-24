using Microsoft.AspNetCore.Mvc;
using NetCore_01.Models;
using System.Diagnostics;

namespace NetCore_01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View("Index");
        }

    }
}