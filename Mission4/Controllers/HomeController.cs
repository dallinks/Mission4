using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private NewMovieContext _NewMovieContextFile { get; set; }

        public HomeController(NewMovieContext someName)
        {
            _NewMovieContextFile = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNewMovie()
        {
            ViewBag.Category = _NewMovieContextFile.Categories.ToList();
            return View("NewMovie",new ApplicationResponse());
        }
        [HttpPost]
        public IActionResult AddNewMovie(ApplicationResponse response)
        {
            if (ModelState.IsValid)
            {
                _NewMovieContextFile.Add(response);
                _NewMovieContextFile.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Category = _NewMovieContextFile.Categories.ToList();
                return View("NewMovie");
            }
        }
        
        public IActionResult MovieList()
        {
            var applications = _NewMovieContextFile.Responses.Include(x => x.Category).ToList();

            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Category = _NewMovieContextFile.Categories.ToList();
            var application = _NewMovieContextFile.Responses.Single(x => x.MovieID == id);
            return View("NewMovie",application);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse blah)
        {
            _NewMovieContextFile.Update(blah);
            _NewMovieContextFile.SaveChanges();
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var application = _NewMovieContextFile.Responses.Single(x => x.MovieID == id);

            return View("Delete",application);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            _NewMovieContextFile.Responses.Remove(ar);
            _NewMovieContextFile.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}
