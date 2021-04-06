using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using ApplicationCore.Entities;

namespace Infrastructure.Repositories {
    public class MovieRepository : EFRepository<Movie>, IMovieRepository {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext) {
        }


        public async Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies() {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            //skip and take
            return movies;
        }

        public async override Task<Movie> GetByIdAsync(int id) {

            var movies = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);

            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty().AverageAsync(r => r == null? 0:r.Rating);

            return movies;
        }

        /*public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId) {
            var movies = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Id == genreId).DefaultIfEmpty().SelectMany(g => g.Movies).ToListAsync();
            return movies;
        }*/
        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId, int pageSize = 30, int page = 1) {
            var movies = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Id == genreId)
                .SelectMany(g => g.Movies).OrderByDescending(m => m.Revenue).Skip((page - 1) * pageSize).Take(pageSize)
                .ToListAsync();

            return movies;
        }

        /*public async Task<IEnumerable<Movie>> GetMoviesByMovieCastAsync(int castId) {
            var movies = await _dbContext.MovieCasts.Include(c => c.Movie).Where(c => c.CastId == castId).DefaultIfEmpty().SelectMany(c => c.Movie).ToListAsync();
            return movies;
        }*/

        /*public override Task<IEnumerable<Movie>> ListAsync(Expression<Func<Movie, bool>> filter) {
            var movies = _dbContext.Movies.Where(m => m.Revenue > 100000).ToListAsync();
            
        }*/
    }
}
