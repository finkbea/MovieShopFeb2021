using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Response;

namespace Infrastructure.Services {
    public class CastService : ICastService {
        private readonly IAsyncRepository<Cast> _castRepository;

        public CastService(IAsyncRepository<Cast> castRepository) {
            _castRepository = castRepository;
        }
        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id) {
            var cast = await _castRepository.GetByIdAsync(id);
            var castMovies = new List<MovieResponseModel>();

            foreach (var movie in cast.MovieCasts) {
                castMovies.Add(new MovieResponseModel()
                {
                    Id = movie.MovieId,
                    PosterUrl = movie.Movie.PosterUrl,
                    Title = movie.Movie.Title
                });
            }
            var result = new CastDetailsResponseModel();
            result.Id = cast.Id;
            result.Name = cast.Name;
            result.Gender = cast.Gender;
            result.TmdbUrl = cast.TmdbUrl;
            result.ProfilePath = cast.ProfilePath;
            result.Movies = castMovies;

            return result;
        }
    }
}
