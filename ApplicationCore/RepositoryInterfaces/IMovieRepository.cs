using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces {
    public interface IMovieRepository : IAsyncRepository<Movie> {
        Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies();
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId, int pageSize = 25, int page = 1);
        Task<IEnumerable<Movie>> GetTopGrossing();
        Task<IEnumerable<Movie>> GetTopRated();

        Task<IEnumerable<Movie>> GetAll();
        //Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
        /*Task<IEnumerable<Movie>> GetMoviesByMovieCastAsync(int castId);*/
    }
}
