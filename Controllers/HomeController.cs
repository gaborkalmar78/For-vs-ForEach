using For_vs_ForEach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace For_vs_ForEach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

[HttpGet]
public IActionResult Index()
{
    var model = new ViewModel()
    {
        Items = new List<Item>()
        {
            new Item() { Id = Guid.NewGuid(), Name = "First"},
            new Item() { Id = Guid.NewGuid(), Name = "Second"},
            new Item() { Id = Guid.NewGuid(), Name = "Third"},
        }
    };
    return View(model);
}

[HttpPost]
public IActionResult Index(ViewModel model)
{
    //Remode "Second"
    model.Items.RemoveAt(1);

    return View(model);
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
