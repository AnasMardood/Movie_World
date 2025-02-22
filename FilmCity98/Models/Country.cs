using System.Collections;

namespace FilmCity98.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
