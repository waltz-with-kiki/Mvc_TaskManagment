using Microsoft.AspNetCore.Mvc;
using NewProject.Data.Models;

namespace NewProject.Controllers
{
    public class MainController : Controller
    {
        private readonly MonadaMech _db;

        public MainController(MonadaMech db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
