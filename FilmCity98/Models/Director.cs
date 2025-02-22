namespace FilmCity98.Models
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }  
        public DateTime DateOfBirth { get; set; }  
        public string Bio { get; set; }  
        public virtual ICollection<Movie>? Movie { get; set; }
    }
}
