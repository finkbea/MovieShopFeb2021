using System;
using Shop.Data.Repository;
using Shop.Data.Models;


namespace CastShop {
    class CastServices {

        private readonly castRepository CastRepository;
        public CastServices() {
            castRepository = new CastRepository();
        }

        public async Task PrintAllAsync() {
            var castCollection = await castRepository.GetAllAsync();
            foreach (var i in castCollection) {
                Console.WriteLine(i.Id + " \t " + i.id);
            }
        }

        public async Task<int> Insert(Cast item) {
            return await castRepository.Insert();
        }

        public async Task<int> Delete(Cast item) {
            return await castRepository.Delete();
        }

        public async Task<int> Update(Cast item) {
            return await castRepository.Update();
        }

        public async Task<Cast> GetById(int id) {
            return await castRepository.GetById();
        }

        public async void Run() {
            await PrintAllAsync();
        }
    }
}
