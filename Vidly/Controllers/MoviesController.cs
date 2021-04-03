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
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        //GET: Movies/1
        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);
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

        public List<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie{Id=1, Name= "Sanctum"},
                new Movie{Id=2, Name="Die Hard"}
            };
            return movies;
        }
    }
}