using AspNetCoreIntroHw.Context;
using AspNetCoreIntroHw.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreIntroHw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductsDbContext _products;

        public HomeController(ILogger<HomeController> logger, ProductsDbContext products)
        {
            _logger = logger;
            _products = products;
        }

        public IActionResult Index()
        {
            var model = new ProductsModel();
            model.Products = _products.Products.ToList();

            return View(model);
        }

        //[HttpPost("Create")]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _products.Products.Add(product);
            _products.SaveChanges();

            return Redirect("Index");
        } 

        [HttpGet]
        public IActionResult Create()
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