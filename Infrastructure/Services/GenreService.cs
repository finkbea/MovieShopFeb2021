﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services {
    public class GenreService : IGenreService {
        private readonly IAsyncRepository<Genre> _genreRepository;
        private readonly IMemoryCache _cache;
        private const string genresCacheKey = "genres";
        private readonly TimeSpan _cacheDuration = TimeSpan.FromDays(20);

        public GenreService (IAsyncRepository<Genre> genreRepository, IMemoryCache cache) {
            _genreRepository = genreRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenres() {
            var genres = await _cache.GetOrCreateAsync(genresCacheKey, CacheCheck);
            return genres;
        }
        private async Task<IEnumerable<GenreModel>> CacheCheck(ICacheEntry entry) {
            entry.SlidingExpiration = _cacheDuration;
            var genres = await _genreRepository.ListAllAsync();
            var result = new List<GenreModel>();
            foreach (var genre in genres) {
                result.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return result.OrderBy(g => g.Name); 
        }
    }
}
