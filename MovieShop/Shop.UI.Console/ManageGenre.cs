using System;
using Shop.Data.Repository;
using Shop.Data.Models;
using Shop.Services;

namespace MovieShop {
    class ManageGenre {

        private readonly GenreServices genreServices;
        public manageGenre() {
            genreServices = new GenreServices();
        }

        public async Task PrintAllAsync() {
            var genreCollection = await GenreRepository.GetAllAsync();
            foreach (var i in genreCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        void AddGenre() {
            Genre genre = new Genre();
            Console.WriteLine("Enter Genre Name to add");
            genre.Name = Console.ReadLine();
            if (genreServices.Insert(genre) > 0) {
                Console.WriteLine("Genre added");
            }
            else {
                Console.WriteLine("Error adding genre");
            }
        }

        void DeleteGenre() {
            Genre genre = new Genre();
            Console.WriteLine("Enter Genre Id to delete");
            genre.Id = Console.ReadLine();
            if (genreServices.Delete(genre) > 0) {
                Console.WriteLine("Genre removed");
            }
            else {
                Console.WriteLine("Error removing genre");
            }
        }

        void UpdateGenre() {
            Genre genre = new Genre();
            Console.WriteLine("Enter Genre Id to update");
            genre.Id = Console.ReadLine();
            if (genreServices.Update(genre) > 0) {
                Console.WriteLine("Genre updated");
            }
            else {
                Console.WriteLine("Error updating genre");
            }
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
