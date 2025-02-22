namespace FilmCity98.Models
{
    public class Categories
    {
        public int CategoriesId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
