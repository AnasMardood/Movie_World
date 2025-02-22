using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmCity98.Data;
using FilmCity98.Models;
using FilmCity98.Migrations;
using FilmCity98.Service;
using Microsoft.AspNetCore.Authorization;
using FilmCity98.ViewModels;
using System.Diagnostics;

namespace FilmCity98.Controllers
{
    [Authorize(Roles = WebSiteRole.WebSite_Admin)]
    public class MoviesController : Controller
    {
        private readonly MoviesContext _context;
        public MoviesController(MoviesContext context)
        {
            _context = context;
           
        }

        // GET: Movies
        public  IActionResult Index(string searchTitle)
        {
            var movies =  _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Language)
                .Include(m => m.Country)
                .Include(m => m.Director)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieProducers).ThenInclude(mp => mp.Producer)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTitle))
            {
                movies = movies.Where(m => m.Title.Contains(searchTitle));
                ViewBag.SearchTerm = searchTitle;
            }
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Language)
                .Include(m => m.Country)
                .Include(m => m.Director)
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieProducers).ThenInclude(mp => mp.Producer)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null) return NotFound();

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {

            var viewModel = new MovieViewModel
            {
                Categories = new SelectList(_context.Categories, "CategoriesId", "Name"),
                Directors = new SelectList(_context.Directors, "DirectorId", "Name"),
                Languages = new SelectList(_context.Languages, "LanguageId", "Name"),
                Countries = new SelectList(_context.Countries, "Id", "Name"),
                Actors = new MultiSelectList(_context.Actors, "ActorId", "Name"),
                Producers = new MultiSelectList(_context.Producers, "ProducerId", "Name")
            };

            return View(viewModel);
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Title = model.Title,
                    Description = model.Description,
                    ReleaseDate = model.ReleaseDate,
                    PosterUrl = model.PosterUrl,
                    Rating = model.Rating,
                    BoxOffice = model.BoxOffice,
                    TrailerURL = model.TrailerURL,
                    CategoryId = model.CategoryId,
                    DirectorId = model.DirectorId,
                    LanguageId = model.LanguageId,
                    CountryId = model.CountryId,
                    MovieActors = model.ActorIds?.Select(actorId => new MovieActors { ActorId = actorId }).ToList(),
                    MovieProducers = model.ProducerIds?.Select(producerId => new MovieProducers { ProducerId = producerId }).ToList()
                };

                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Debug.WriteLine(error.ErrorMessage);
                    }
                }
            }

            // If we got this far, something failed; redisplay form
            model.Categories = new SelectList(_context.Categories, "CategoriesId", "Name", model.CategoryId);
            model.Directors = new SelectList(_context.Directors, "DirectorId", "Name", model.DirectorId);
            model.Languages = new SelectList(_context.Languages, "LanguageId", "Name", model.LanguageId);
            model.Countries = new SelectList(_context.Countries, "Id", "Name", model.CountryId);
            model.Actors = new MultiSelectList(_context.Actors, "ActorId", "Name", model.ActorIds);
            model.Producers = new MultiSelectList(_context.Producers, "ProducerId", "Name", model.ProducerIds);

            return View(model);

        }


        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _context.Movies
                .Include(m => m.MovieActors)
                .Include(m => m.MovieProducers)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null) return NotFound();

            var viewModel = new MovieViewModel
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                PosterUrl = movie.PosterUrl,
                Rating = movie.Rating,
                BoxOffice = movie.BoxOffice,
                TrailerURL = movie.TrailerURL,
                CategoryId = movie.CategoryId,
                DirectorId = movie.DirectorId,
                LanguageId = movie.LanguageId,
                CountryId = movie.CountryId,
                ActorIds = movie.MovieActors?.Select(ma => ma.ActorId).ToList(),
                ProducerIds = movie.MovieProducers?.Select(mp => mp.ProducerId).ToList(),
                Categories = new SelectList(_context.Categories, "CategoriesId", "Name", movie.CategoryId),
                Directors = new SelectList(_context.Directors, "DirectorId", "Name", movie.DirectorId),
                Languages = new SelectList(_context.Languages, "LanguageId", "Name", movie.LanguageId),
                Countries = new SelectList(_context.Countries, "Id", "Name", movie.CountryId),
                Actors = new MultiSelectList(_context.Actors, "ActorId", "Name", movie.MovieActors?.Select(ma => ma.ActorId)),
                Producers = new MultiSelectList(_context.Producers, "ProducerId", "Name", movie.MovieProducers?.Select(mp => mp.ProducerId))
            };

            return View(viewModel);

        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieViewModel model)
        {
            if (id != model.MovieId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var movie = await _context.Movies
                        .Include(m => m.MovieActors)
                        .Include(m => m.MovieProducers)
                        .FirstOrDefaultAsync(m => m.MovieId == id);

                    if (movie == null) return NotFound();

                    movie.Title = model.Title;
                    movie.Description = model.Description;
                    movie.ReleaseDate = model.ReleaseDate;
                    movie.PosterUrl = model.PosterUrl;
                    movie.Rating = model.Rating;
                    movie.BoxOffice = model.BoxOffice;
                    movie.TrailerURL = model.TrailerURL;
                    movie.CategoryId = model.CategoryId;
                    movie.DirectorId = model.DirectorId;
                    movie.LanguageId = model.LanguageId;
                    movie.CountryId = model.CountryId;

                    // Update actors
                    movie.MovieActors.Clear();
                    if (model.ActorIds != null)
                    {
                        foreach (var actorId in model.ActorIds)
                        {
                            movie.MovieActors.Add(new MovieActors { MovieId = id, ActorId = actorId });
                        }
                    }

                    // Update producers
                    movie.MovieProducers.Clear();
                    if (model.ProducerIds != null)
                    {
                        foreach (var producerId in model.ProducerIds)
                        {
                            movie.MovieProducers.Add(new MovieProducers { MovieId = id, ProducerId = producerId });
                        }
                    }

                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(model.MovieId)) return NotFound();
                    throw;
                }

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                  .Include(m => m.MovieActors)
                  .Include(m => m.MovieProducers)
                  .FirstOrDefaultAsync(m => m.MovieId == id);
            var viewModel = new MovieViewModel
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                PosterUrl = movie.PosterUrl,
                Rating = movie.Rating,
                BoxOffice = movie.BoxOffice,
                TrailerURL = movie.TrailerURL,
                CategoryId = movie.CategoryId,
                DirectorId = movie.DirectorId,
                LanguageId = movie.LanguageId,
                CountryId = movie.CountryId,
                ActorIds = movie.MovieActors?.Select(ma => ma.ActorId).ToList(),
                ProducerIds = movie.MovieProducers?.Select(mp => mp.ProducerId).ToList(),
                Categories = new SelectList(_context.Categories, "CategoriesId", "Name", movie.CategoryId),
                Directors = new SelectList(_context.Directors, "DirectorId", "Name", movie.DirectorId),
                Languages = new SelectList(_context.Languages, "LanguageId", "Name", movie.LanguageId),
                Countries = new SelectList(_context.Countries, "Id", "Name", movie.CountryId),
                Actors = new MultiSelectList(_context.Actors, "ActorId", "Name", movie.MovieActors?.Select(ma => ma.ActorId)),
                Producers = new MultiSelectList(_context.Producers, "ProducerId", "Name", movie.MovieProducers?.Select(mp => mp.ProducerId))
            };
            if (movie == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
        private bool MovieExists(int? movieId)
        {
            throw new NotImplementedException();
        }

    }
}

