using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre).ToList();
            return View(movies);
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shark!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Oumayma"},
                new Customer {Name = "Nadwa"},
                new Customer {Name = "Mohamed"},
                //new Customer {Name = "Marwa"}

            };

            var ViewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                customers = customers
            };
            return View(ViewModel);
            //return Content("hello Mimi");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1 });
        }
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        //public ActionResult Index(int? pageNumber, string sortBy) {
        //    if (!pageNumber.HasValue)
        //        pageNumber = 1;
        //    if(String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageNumber={0} & sortBy={1}", pageNumber,sortBy));
        //}
        //regex : regular expression. regex and range .. = contraints 
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
       public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int?id)
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            Movie movie = movies.Where(m => m.Id == id).SingleOrDefault();
            return View(movie);
        }

        public ActionResult Create()
        {
            var model = new FormMovieViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(Movie Movie)
        {
            if (Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(Movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Movie.Id);
                movieInDb.Name = Movie.Name;
                movieInDb.NumberInStock = Movie.NumberInStock;
                movieInDb.ReleaseDate = Movie.ReleaseDate;
                movieInDb.GenreId = Movie.GenreId;
            }

            //try
            //{
            //    _context.SaveChanges();
            //}
            //catch(DbEntityValidationException e)
            //{
            //    Console.WriteLine(e);
            //}

            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var createMovieViewModel = new FormMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("Create", createMovieViewModel);
        }
    }
}