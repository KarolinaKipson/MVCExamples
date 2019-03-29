using Entity.MoviesDb.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Entity.MoviesDb.Controllers
{
    public class MovieController : Controller
    {
        private EntityMoviesDB db = new EntityMoviesDB();

        // GET: Movie
        public ActionResult Index(string searchString)
        {
            //query
            var movies = from m in db.Movies select m;

            //LINQ queries are not executed when they are defined or when they are modified by calling a method such as Where or OrderBy. 
            //Instead, query execution is deferred, which means that the evaluation of an expression is delayed until its realized value is 
            //actually iterated over or the ToList method is called. In the Search sample, the query is executed in the Index.cshtml view.
            //The Contains method is run on the database, not the c# code above. On the database, Contains maps to SQL LIKE, which is case insensitive.
            if (!string.IsNullOrEmpty(searchString)) 
            {
                movies = movies.Where(x => x.Title.Contains(searchString));
            }
            return View(movies);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }


            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId, Title, DirectorName, ReleaseDate")]Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId, Title, DirectorName, ReleaseDate")]Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}