using System;
using System.Linq;

namespace MovieShop {
    class Program {
        static void Main(string[] args) {

            ManageGenre manageGenre = new ManageGenre();
            manageGenre.Run();

            Console.Read();
        }
    }
}
