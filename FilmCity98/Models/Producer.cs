namespace FilmCity98.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
