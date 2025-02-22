namespace FilmCity98.Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public string Name { get; set; }  // اسم الجائزة
        public string Category { get; set; } 
        public DateTime Year { get; set; }  

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
