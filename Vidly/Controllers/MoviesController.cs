using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };
            return View("MovieForm", viewModel);
        }



        // EDIT: Movie
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }



        // SAVE: Movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            
            // Checking form validation 
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            
            // If movie is not in Db i.e. New movie
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            // Edit existing movie in Db
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NrInStock = movie.NrInStock;
            }

            _context.SaveChanges();
            
            // Redirect to Index view after saving data to Db
            return RedirectToAction("Index", "Movies");
        }


       

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies;
            return View(movies);
        }

        //GET: Movies/1
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }



        // RANDOM movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shawshank Redemption" };
            var customers = new List<Customer>
            {
                new Customer(){Name = "Bishal S."},
                new Customer(){Name = "Binayak K."}
            };

            RandomMovieViewModel randomMovieViewModel = new RandomMovieViewModel
            {
                RandomMovie = movie,
                Customers = customers
            };

            return View(randomMovieViewModel);
        }
        
    }
}