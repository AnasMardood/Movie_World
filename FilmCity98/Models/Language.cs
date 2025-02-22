namespace FilmCity98.Models
{
    public class Language
    {
        public int LanguageId {  get; set; }
        public string Name {  get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
