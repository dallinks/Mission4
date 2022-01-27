using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NewMovieContext _NewMovieContextFile { get; set; }

        public HomeController(ILogger<HomeController> logger, NewMovieContext someName)
        {
            _logger = logger;
            _NewMovieContextFile = someName;
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
        [HttpGet]
        public IActionResult AddNewMovie()
        {
            return View("NewMovie");
        }
        [HttpPost]
        public IActionResult AddNewMovie(ApplicationResponse response)
        {
            _NewMovieContextFile.Add(response);
            _NewMovieContextFile.SaveChanges();
            return View("Confirmation",response);
        }
    }
}
