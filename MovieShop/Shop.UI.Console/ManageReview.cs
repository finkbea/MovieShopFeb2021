using System;
using Shop.Data.Repository;
using Shop.Data.Models;
using Shop.Services;

namespace MovieShop {
    class ManageReview {

        private readonly ReviewServices reviewServices;
        public manageReview() {
            reviewServices = new ReviewServices();
        }

        public async Task PrintAllAsync() {
            var reviewCollection = await ReviewRepository.GetAllAsync();
            foreach (var i in reviewCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        void AddReview() {
            Review review = new Review();
            Console.WriteLine("Enter Review MovieId to add");
            review.MovieId = Console.ReadLine();
            if (reviewServices.Insert(review) > 0) {
                Console.WriteLine("Review added");
            }
            else {
                Console.WriteLine("Error adding review");
            }
        }

        void DeleteReview() {
            Review review = new Review();
            Console.WriteLine("Enter Review Id to delete");
            review.MovieId = Console.ReadLine();
            if (reviewServices.Delete(review) > 0) {
                Console.WriteLine("Review removed");
            }
            else {
                Console.WriteLine("Error removing review");
            }
        }

        void UpdateReview() {
            Review review = new Review();
            Console.WriteLine("Enter Review Id to update");
            review.MovieId = Console.ReadLine();
            if (reviewServices.Update(review) > 0) {
                Console.WriteLine("Review updated");
            }
            else {
                Console.WriteLine("Error updating review");
            }
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
