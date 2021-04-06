using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;

namespace ApplicationCore.ServiceInterfaces {

    public interface IMovieService {

        Task<List<MovieCardResponseModel>> Get30HighestGrossing();  
        void CreateMovie(MovieCreateRequestModel model);

        Task<MovieDetailsResponseModel> GetMovieAsync(int id);
        Task<IEnumerable<MovieResponseModel>> GetMoviesByGenreAsync(int id);
        //Task<IEnumerable<MovieCardResponseModel>> GetMoviesByMovieCastsAsync(int castId);
        /*Task<PagedResultSet<MovieDetailsResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 1, string title = "");
        Task<PagedResultSet<MovieDetailsResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 1);
        Task<PagedResultSet<MovieDetailsResponseModel>> GetAllPurchasesByMovieId(int movieId);
        Task<PaginatedList<MovieDetailsResponseModel>> GetMoviesByGenre(int genreId, int pageSize = 25, int page = 1);

        Task<MovieDetailsResponseModel> GetMovieAsync(int id);
        Task<int> GetMoviesCount(string title = "");
        Task<IEnumerable<MovieDetailsResponseModel>> GetTopRatedMovies();
        Task<IEnumerable<MovieDetailsResponseModel>> GetHighestGrossingMovies();

        Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequest);
        Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequestModel movieCreateRequest);*/
    }

}
