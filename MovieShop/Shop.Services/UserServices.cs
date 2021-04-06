using System;
using Shop.Data.Repository;
using Shop.Data.Models;


namespace MovieShop {
    class UserServices {

        private readonly UserRepository userRepository;
        public UserServices() {
            userRepository = new UserRepository();
        }

        public async Task PrintAllAsync() {
            var userCollection = await UserRepository.GetAllAsync();
            foreach (var i in userCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        public async Task<int> Insert(User item) {
            return await userRepository.Insert();
        }

        public async Task<int> Delete(User item) {
            return await userRepository.Delete();
        }

        public async Task<int> Update(User item) {
            return await userRepository.Update();
        }

        public async Task<User> GetById(int id) {
            return await userRepository.GetById();
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
