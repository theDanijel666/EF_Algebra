using Connection_String_custom.Models;
using Connection_String_custom.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Connection_String_custom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HomeRepository _repo;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _repo = new HomeRepository(configuration);
        }

        public IActionResult Index()
        {
            bool con = _repo.CheckExistingConnection();
            if (con) ViewBag.Message = "Konekcija otvorena :)";
            else ViewBag.Message = "Konekcija nije uspjela!";

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
    }
}
