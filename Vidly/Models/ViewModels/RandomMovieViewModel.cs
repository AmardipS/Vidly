using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie RandomMovie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}