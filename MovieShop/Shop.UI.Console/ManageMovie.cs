using System;
using Shop.Data.Repository;
using Shop.Data.Models;
using Shop.Services;

namespace MovieShop {
    class ManageMovie {

        private readonly MovieServices movieServices;
        public manageMovie() {
            movieServices = new MovieServices();
        }

        public async Task PrintAllAsync() {
            var movieCollection = await MovieRepository.GetAllAsync();
            foreach (var i in movieCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        void AddMovie() {
            Movie movie = new Movie();
            Console.WriteLine("Enter Movie Title to add");
            movie.Title = Console.ReadLine();
            if (movieServices.Insert(movie) > 0) {
                Console.WriteLine("Movie added");
            }
            else {
                Console.WriteLine("Error adding movie");
            }
        }

        void DeleteMovie() {
            Movie movie = new Movie();
            Console.WriteLine("Enter Movie Id to delete");
            movie.Id = Console.ReadLine();
            if (movieServices.Delete(movie) > 0) {
                Console.WriteLine("Movie removed");
            }
            else {
                Console.WriteLine("Error removing movie");
            }
        }

        void UpdateMovie() {
            Movie movie = new Movie();
            Console.WriteLine("Enter Movie Id to update");
            movie.Id = Console.ReadLine();
            if (movieServices.Update(movie) > 0) {
                Console.WriteLine("Movie updated");
            }
            else {
                Console.WriteLine("Error updating movie");
            }
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
