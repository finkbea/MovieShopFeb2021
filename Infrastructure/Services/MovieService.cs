using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;

namespace Infrastructure.Services {
    public class MovieService : IMovieService {

        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository) {
            _movieRepository = movieRepository;
        }
        public async Task<List<MovieCardResponseModel>> Get30HighestGrossing() {
            
            var movies = await _movieRepository.GetTop30HighestGrossingMovies();

            var result = new List<MovieCardResponseModel>();

            foreach (var movie in movies) {
                result.Add(
                new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return result;
        }

        //populates genre and cast lists for each movie, then adds them to the created MovieDetailsResponseModel
        public async Task<MovieDetailsResponseModel> GetMovieAsync(int id) {
            var movie = await _movieRepository.GetByIdAsync(id);
            var genres = new List<GenreModel>();
            foreach (var genre in movie.Genres) {
                genres.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            var casts = new List<MovieDetailsResponseModel.CastResponseModel>();
            foreach (var cast in movie.MovieCasts) {
                casts.Add(new MovieDetailsResponseModel.CastResponseModel
                {
                    Id = cast.CastId,
                    Name = cast.Cast.Name,
                    Gender = cast.Cast.Gender,
                    TmdbUrl = cast.Cast.TmdbUrl,
                    ProfilePath = cast.Cast.ProfilePath,
                    Character = cast.Character
                });
            }
            var result = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Rating = movie.Rating,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,
                Genres = genres,
                Casts = casts
            };

            return result; 
        }

        public async Task<IEnumerable<MovieResponseModel>> GetMoviesByGenreAsync(int id) {
            var movies = await _movieRepository.GetMoviesByGenreAsync(id);
            var result = new List<MovieResponseModel>();
            foreach (var movie in movies) {
                result.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    Title=movie.Title,
                    PosterUrl=movie.PosterUrl,
                    ReleaseDate =movie.ReleaseDate
                });
            }
            return result;
        }

        /*public async Task<IEnumerable<MovieCardResponseModel>> GetMoviesByMovieCastAsync(int castId) {
            var movies = await _movieRepository.GetMoviesByMovieCastAsync(castId);
            var result = new List<MovieCardResponseModel>();
            foreach (var movie in movies) {
                result.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return result;
        }*/

        public void CreateMovie(MovieCreateRequestModel model) {
            //take model and convert it to movie entity and send it to repository
            //if repository saves successfully return true/id:2
        }

    }
}
