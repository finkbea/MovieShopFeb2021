using System;
using Shop.Data.Repository;
using Shop.Data.Models;


namespace MovieShop {
    class ReviewServices {

        private readonly reviewRepository ReviewRepository;
        public ReviewServices() {
            reviewRepository = new ReviewRepository();
        }

        public async Task PrintAllAsync() {
            var reviewCollection = await reviewRepository.GetAllAsync();
            foreach (var i in reviewCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        public async Task<int> Insert(Review item) {
            return await reviewRepository.Insert();
        }

        public async Task<int> Delete(Review item) {
            return await reviewRepository.Delete();
        }

        public async Task<int> Update(Review item) {
            return await reviewRepository.Update();
        }

        public async Task<Review> GetById(int id) {
            return await reviewRepository.GetById();
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
