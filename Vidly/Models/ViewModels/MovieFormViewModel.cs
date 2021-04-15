using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        
        
       /*

       public int? Id { get; set; }

       [Required]
       [StringLength(255)]
       public string Name { get; set; }

       [Required]
       [Display(Name = "Genre")]
       public byte? GenreId { get; set; }

       [Required]
       [Display(Name = "Release Date")]
       public DateTime? ReleaseDate { get; set; }

       [Required]
       [Range(1, 20)]
       [Display(Name = "Number in Stock")]
       public byte? NrInStock { get; set; }

       public MovieFormViewModel()
       {
           Id = 0;
       }

       */
    }
}