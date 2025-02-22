using FilmCity98.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FilmCity98.ViewModels
{
    public class MovieViewModel
    {


        public int? MovieId { get; set; } 

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }

        public string? PosterUrl { get; set; }

        public double Rating { get; set; }

        public decimal BoxOffice { get; set; }
        public string? TrailerURL { get; set; }

        //[Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        //[Required(ErrorMessage = "Director is required")]
        public int DirectorId { get; set; }

      //  [Required(ErrorMessage = "Language is required")]
        public int LanguageId { get; set; }

      //  [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        public List<int> ActorIds { get; set; } = new List<int>();
        public List<int> ProducerIds { get; set; } = new List<int>();

      
        public SelectList? Categories { get; set; }
        public SelectList? Directors { get; set; }
        public SelectList? Languages { get; set; }
        public SelectList? Countries { get; set; }
        public MultiSelectList? Actors { get; set; }
        public MultiSelectList? Producers { get; set; }
    }

}
