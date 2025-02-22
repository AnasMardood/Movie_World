namespace FilmCity98.Models
{
    public class Dashboard
    {
        public int TotalMovies { get; set; }
        public int TotalActors { get; set; }
        public int TotalDirectors { get; set; }
        public int TotalUsers { get; set; }
        // Movie Overview
        public List<MovieOverviewDto> RecentMovies { get; set; }
        public Dictionary<string, int> MoviesByCategory { get; set; }

        // User Overview
        public List<UserOverviewDto> RecentUsers { get; set; }
        public Dictionary<string, int> UsersByRole { get; set; }
    }

    public class MovieOverviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterURL { get; set; }
        public string Category { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public double Rating { get; set; }
    }

    public class UserOverviewDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }
    }
}
