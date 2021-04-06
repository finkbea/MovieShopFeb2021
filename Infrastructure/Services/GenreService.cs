using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;

namespace Infrastructure.Services {
    public class GenreService : IGenreService {
        private readonly IAsyncRepository<Genre> _genreRepository;

        public GenreService (IAsyncRepository<Genre> genreRepository) {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenres() {
            var genres = await _genreRepository.ListAllAsync();

            var result = new List<GenreModel>();
            foreach (var genre in genres) {
                result.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return result;
        }
    }
}
