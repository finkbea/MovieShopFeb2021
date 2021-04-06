using System;
using Shop.Data.Repository;
using Shop.Data.Models;


namespace MovieShop {
    class GenreServices {

        private readonly GenreRepository genreRepository;
        public GenreServices() {
            genreRepository = new GenreRepository();
        }

        public async Task PrintAllAsync() {
            var genreCollection = await GenreRepository.GetAllAsync();
            foreach (var i in genreCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        public async Task<int> Insert(Genre item) {
            return await genreRepository.Insert();
        }

        public async Task<int> Delete(Genre item) {
            return await genreRepository.Delete();
        }

        public async Task<int> Update(Genre item) {
            return await genreRepository.Update();
        }

        public async Task<Genre> GetById (int id) {
            return await genreRepository.GetById();
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
