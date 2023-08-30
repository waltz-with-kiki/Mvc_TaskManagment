using Microsoft.AspNetCore.Mvc;
using NewProject.DAL;

namespace NewProject.Controllers
{
    public class MainController : Controller
    {
        public MonadaMech _db;

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
