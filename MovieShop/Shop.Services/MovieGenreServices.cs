using System;
using Shop.Data.Repository;
using Shop.Data.Models;


namespace MovieGenreShop {
    class MovieGenreServices {

        private readonly movieGenreRepository MovieGenreRepository;
        public MovieGenreServices() {
            movieGenreRepository = new MovieGenreRepository();
        }

        public async Task PrintAllAsync() {
            var movieGenreCollection = await movieGenreRepository.GetAllAsync();
            foreach (var i in movieGenreCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        public async Task<int> Insert(MovieGenre item) {
            return await movieGenreRepository.Insert();
        }

        public async Task<int> Delete(MovieGenre item) {
            return await movieGenreRepository.Delete();
        }

        public async Task<int> Update(MovieGenre item) {
            return await movieGenreRepository.Update();
        }

        public async Task<MovieGenre> GetById(int id) {
            return await movieGenreRepository.GetById();
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
