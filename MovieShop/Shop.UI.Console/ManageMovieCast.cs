using System;
using Shop.Data.Repository;
using Shop.Data.Models;
using Shop.Services;

namespace MovieShop {
    class ManageMovieCast {

        private readonly MovieCastServices movieCastServices;
        public manageMovieCast() {
            movieCastServices = new MovieCastServices();
        }

        public async Task PrintAllAsync() {
            var movieCastCollection = await MovieCastRepository.GetAllAsync();
            foreach (var i in movieCastCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        void AddMovieCast() {
            MovieCast movieCast = new MovieCast();
            Console.WriteLine("Enter MovieCast MovieId to add");
            movieCast.MovieId = Console.ReadLine();
            if (movieCastServices.Insert(movieCast) > 0) {
                Console.WriteLine("MovieCast added");
            }
            else {
                Console.WriteLine("Error adding movieCast");
            }
        }

        void DeleteMovieCast() {
            MovieCast movieCast = new MovieCast();
            Console.WriteLine("Enter MovieCast Id to delete");
            movieCast.Id = Console.ReadLine();
            if (movieCastServices.Delete(movieCast) > 0) {
                Console.WriteLine("MovieCast removed");
            }
            else {
                Console.WriteLine("Error removing movieCast");
            }
        }

        void UpdateMovieCast() {
            MovieCast movieCast = new MovieCast();
            Console.WriteLine("Enter MovieCast Id to update");
            movieCast.Id = Console.ReadLine();
            if (movieCastServices.Update(movieCast) > 0) {
                Console.WriteLine("MovieCast updated");
            }
            else {
                Console.WriteLine("Error updating movieCast");
            }
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
