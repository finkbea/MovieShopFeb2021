using System;
using Shop.Data.Repository;
using Shop.Data.Models;


namespace MovieCastShop {
    class MovieCastServices {

        private readonly movieCastRepository MovieCastRepository;
        public MovieCastServices() {
            movieCastRepository = new MovieCastRepository();
        }

        public async Task PrintAllAsync() {
            var movieCastCollection = await movieCastRepository.GetAllAsync();
            foreach (var i in movieCastCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        public async Task<int> Insert(MovieCast item) {
            return await movieCastRepository.Insert();
        }

        public async Task<int> Delete(MovieCast item) {
            return await movieCastRepository.Delete();
        }

        public async Task<int> Update(MovieCast item) {
            return await movieCastRepository.Update();
        }

        public async Task<MovieCast> GetById(int id) {
            return await movieCastRepository.GetById();
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
