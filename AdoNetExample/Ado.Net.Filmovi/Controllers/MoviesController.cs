using Ado.Net.Filmovi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ado.Net.Filmovi.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            MovieRepository movieRepo = new MovieRepository();
            var model = movieRepo.getAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            MovieRepository movieRepo = new MovieRepository();
            movie = movieRepo.Create(movie);
            return RedirectToAction("Index", movie);
        }

        public ActionResult Edit(int id)
        {
            MovieRepository movieRepo = new MovieRepository();
            var model = movieRepo.getOne(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            MovieRepository movieRepo = new MovieRepository();
            movieRepo.Update(movie);

            return RedirectToAction("Index", movie);
        }

        public ActionResult Details(int id)
        {
            MovieRepository movieRepo = new MovieRepository();
            Movie movie = movieRepo.getOne(id);
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            MovieRepository movieRepo = new MovieRepository();
            movieRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}