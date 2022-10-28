using Microsoft.AspNetCore.Mvc;
using SE1634_Group5_A3.Models;
using SE1634_MVC.Models;
using System.Diagnostics;

namespace SE1634_Group5_A3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {
            MusicStoreContext context = new MusicStoreContext();
            User user = context.Users.Where(u => u.UserName == UserName
                && u.Password == Password).FirstOrDefault();

            if (user == null)
                return View();
            else
            {
                HttpContext.Session.SetString("UserName", UserName);
                HttpContext.Session.SetInt32("Role", user.Role);

                ShoppingCart cart = ShoppingCart.GetCart(HttpContext);
                cart.MigrateCart(HttpContext);
                return RedirectToAction("Index", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}