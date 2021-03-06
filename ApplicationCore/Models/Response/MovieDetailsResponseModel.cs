using System;
using System.Collections.Generic;

namespace ApplicationCore.Models.Response {

    public class RoleModel {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MovieResponseModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }

    public class MovieDetailsResponseModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }

        public decimal? Rating { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public int FavoritesCount { get; set; }
        public List<CastResponseModel> Casts { get; set; }
        public List<GenreModel> Genres { get; set; }

        public class CastResponseModel {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string TmdbUrl { get; set; }
            public string ProfilePath { get; set; }
            public string Character { get; set; }
        }
    }

    public class GenreModel {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class CastDetailsResponseModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }
        public IEnumerable<MovieResponseModel> Movies { get; set; }
    }

    public class MovieReviewResponseModel {
        public int Id { get; set; }
        public List<MovieReviewSubResponseModel> MovieReviews { get; set; }
    }
    public class MovieReviewSubResponseModel {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public decimal? Rating { get; set; }
    }

    public class ReviewResponseModel {
        public int UserId { get; set; }
        public List<ReviewMovieResponseModel> MovieReviews { get; set; }
    }

    public class ReviewMovieResponseModel {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public decimal? Rating { get; set; }
        public string Name { get; set; }
    }
}