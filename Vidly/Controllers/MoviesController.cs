using System;
using System.Collections.Generic;
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