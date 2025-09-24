using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppPelda.Models;

namespace WebAppPelda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Sub3()
        {
            List<Customer> lingling = new CustomerController().GetCustomersFromDataBase();
            return View(lingling);
        }
        public IActionResult CustomerList()
        {
            List<Customer> list = new CustomerController().GetCustomersFromDataBase();
            return View(list);
        }
        public IActionResult SubPage()
        {
            Customer customer = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "123-456-7890",
                Score = 85
            };
            return View(customer);
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
    }
}
