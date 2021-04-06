using System;
using Shop.Data.Repository;
using Shop.Data.Models;
using Shop.Services;

namespace MovieShop {
    class ManageCast {

        private readonly CastServices castServices;
        public manageCast() {
            castServices = new CastServices();
        }

        public async Task PrintAllAsync() {
            var castCollection = await CastRepository.GetAllAsync();
            foreach (var i in castCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        void AddCast() {
            Cast cast = new Cast();
            Console.WriteLine("Enter Cast Name to add");
            cast.Name = Console.ReadLine();
            if (castServices.Insert(cast) > 0) {
                Console.WriteLine("Cast added");
            }
            else {
                Console.WriteLine("Error adding cast");
            }
        }

        void DeleteCast() {
            Cast cast = new Cast();
            Console.WriteLine("Enter Cast Id to delete");
            cast.Id = Console.ReadLine();
            if (castServices.Delete(cast) > 0) {
                Console.WriteLine("Cast removed");
            }
            else {
                Console.WriteLine("Error removing cast");
            }
        }

        void UpdateCast() {
            Cast cast = new Cast();
            Console.WriteLine("Enter Cast Id to update");
            cast.Id = Console.ReadLine();
            if (castServices.Update(cast) > 0) {
                Console.WriteLine("Cast updated");
            }
            else {
                Console.WriteLine("Error updating cast");
            }
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
