using System;
using Shop.Data.Repository;
using Shop.Data.Models;


namespace MovieShop {
    class MovieServices {

        private readonly movieRepository MovieRepository;
        public MovieServices() {
            movieRepository = new MovieRepository();
        }

        public async Task PrintAllAsync() {
            var movieCollection = await movieRepository.GetAllAsync();
            foreach (var i in movieCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        public async Task<int> Insert(Movie item) {
            return await movieRepository.Insert();
        }

        public async Task<int> Delete(Movie item) {
            return await movieRepository.Delete();
        }

        public async Task<int> Update(Movie item) {
            return await movieRepository.Update();
        }

        public async Task<Movie> GetById(int id) {
            return await movieRepository.GetById();
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
