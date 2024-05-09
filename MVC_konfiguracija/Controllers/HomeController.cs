using Microsoft.AspNetCore.Mvc;
using MVC_konfiguracija.Models;
using System.Diagnostics;

namespace MVC_konfiguracija.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login(string username, string password)
        {
            string sqlCommand= "SELECT * FROM users WHERE username='" + username + "' AND password='" + password + "'";

            //SELECT * FROM users WHERE username='admin' AND password='admin'
            //username="admin' OR 1=1; -- "
            //SELECT * FROM users WHERE username='admin' OR 1=1; -- ' AND password='admin'

            return View();
        }
    }
}
