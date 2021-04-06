using System;
using Shop.Data.Repository;
using Shop.Data.Models;
using Shop.Services;

namespace MovieShop {
    class ManageUser {

        private readonly UserServices userServices;
        public manageUser() {
            userServices = new UserServices();
        }

        public async Task PrintAllAsync() {
            var userCollection = await UserRepository.GetAllAsync();
            foreach (var i in userCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        void AddUser() {
            User user = new User();
            Console.WriteLine("Enter User Name to add");
            user.Name = Console.ReadLine();
            if (userServices.Insert(user) > 0) {
                Console.WriteLine("User added");
            }
            else {
                Console.WriteLine("Error adding user");
            }
        }

        void DeleteUser() {
            User user = new User();
            Console.WriteLine("Enter User Id to delete");
            user.Id = Console.ReadLine();
            if (userServices.Delete(user) > 0) {
                Console.WriteLine("User removed");
            }
            else {
                Console.WriteLine("Error removing user");
            }
        }

        void UpdateUser() {
            User user = new User();
            Console.WriteLine("Enter User Id to update");
            user.Id = Console.ReadLine();
            if (userServices.Update(user) > 0) {
                Console.WriteLine("User updated");
            }
            else {
                Console.WriteLine("Error updating user");
            }
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
