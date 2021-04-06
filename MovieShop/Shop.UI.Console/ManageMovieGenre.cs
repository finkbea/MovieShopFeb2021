using System;
using Shop.Data.Repository;
using Shop.Data.Models;
using Shop.Services;

namespace MovieShop {
    class ManageMovieGenre {

        private readonly MovieGenreServices movieGenreServices;
        public manageMovieGenre() {
            movieGenreServices = new MovieGenreServices();
        }

        public async Task PrintAllAsync() {
            var movieGenreCollection = await MovieGenreRepository.GetAllAsync();
            foreach (var i in movieGenreCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        void AddMovieGenre() {
            MovieGenre movieGenre = new MovieGenre();
            Console.WriteLine("Enter MovieGenre MovieId to add");
            movieGenre.MovieId = Console.ReadLine();
            if (movieGenreServices.Insert(movieGenre) > 0) {
                Console.WriteLine("MovieGenre added");
            }
            else {
                Console.WriteLine("Error adding movieGenre");
            }
        }

        void DeleteMovieGenre() {
            MovieGenre movieGenre = new MovieGenre();
            Console.WriteLine("Enter MovieGenre Id to delete");
            movieGenre.MovieId = Console.ReadLine();
            if (movieGenreServices.Delete(movieGenre) > 0) {
                Console.WriteLine("MovieGenre removed");
            }
            else {
                Console.WriteLine("Error removing movieGenre");
            }
        }

        void UpdateMovieGenre() {
            MovieGenre movieGenre = new MovieGenre();
            Console.WriteLine("Enter MovieGenre Id to update");
            movieGenre.MovieId = Console.ReadLine();
            if (movieGenreServices.Update(movieGenre) > 0) {
                Console.WriteLine("MovieGenre updated");
            }
            else {
                Console.WriteLine("Error updating movieGenre");
            }
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
