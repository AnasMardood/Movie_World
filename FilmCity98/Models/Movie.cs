using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCity98.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? PosterUrl { get; set; }
        public double Rating {  get; set; }
        public string? TrailerURL {  get; set; }
        public decimal BoxOffice {  get; set; }

        public int CategoryId { get; set; }
        public Categories Category { get; set; }

        
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Award>? Awards { get; set; }
        public ICollection<MovieActors>? MovieActors { get; set; }
        public ICollection<MovieProducers>? MovieProducers { get; set; }
    }
}