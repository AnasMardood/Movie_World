using FilmCity98.Data;
using FilmCity98.Models;
using FilmCity98.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmCity98.Controllers
{

    
    [Authorize(Roles = WebSiteRole.WebSite_Admin)]
    public class DashboardController : Controller
    {
        private readonly MoviesContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(MoviesContext context , UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Get basic statistics
            var viewModel = new Dashboard
            {
                TotalMovies = await _context.Movies.CountAsync(),
                TotalActors = await _context.Actors.CountAsync(),
                TotalDirectors = await _context.Directors.CountAsync(),
                TotalUsers = await _context.Users.CountAsync(),

                // Get recent movies
                RecentMovies = await _context.Movies
                    .Include(m => m.Category)
                    .Include(m => m.Director)
                    .OrderByDescending(m => m.ReleaseDate)
                    .Take(5)
                    .Select(m => new MovieOverviewDto
                    {
                        Id = m.MovieId,
                        Title = m.Title,
                        PosterURL = m.PosterUrl,
                        Category = m.Category.Name,
                        ReleaseDate = m.ReleaseDate,
                        Director = m.Director.Name,
                        Rating = m.Rating
                    })
                    .ToListAsync(),

                // Get movies by category
                MoviesByCategory = await _context.Movies
                    .GroupBy(m => m.Category.Name)
                    .Select(g => new { Category = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.Category, x => x.Count),

                // Get recent users
                RecentUsers = await _context.Users
                    .OrderByDescending(u => u.JoinDate)
                    .Take(5)
                    .Select(u => new UserOverviewDto
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        Email = u.Email,
                        JoinDate = u.JoinDate,
                        IsActive = u.IsActive
                    })
                    .ToListAsync()
            };

            // Get user roles
            foreach (var user in viewModel.RecentUsers)
            {
                var dbUser = await _userManager.FindByIdAsync(user.Id);
                var _roles = await _userManager.GetRolesAsync(dbUser);

                user.Role = _roles.FirstOrDefault() ?? "User";
            }

            // Get users by role statistics
            viewModel.UsersByRole = new Dictionary<string, int>();
            var roles = await _context.Roles.ToListAsync();
            foreach (var role in roles)
            {
                var count = await _context.UserRoles
                    .Where(ur => ur.RoleId == role.Id)
                    .CountAsync();
                viewModel.UsersByRole.Add(role.Name, count);
            }

            return View(viewModel);
        }
    }
}
