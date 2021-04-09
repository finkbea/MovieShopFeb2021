using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class UserRepository :EFRepository<User>, IUserRepository{
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext) {

        }
        public async Task<User> GetUserByEmail(string email) {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
        //ensures salt exists
        public async Task<bool> SaltExists(string salt) {
            var user= await _dbContext.Users.FirstOrDefaultAsync(u => u.Salt == salt);
            if (user != null) {
                return false;
            }
            return true;
        }
    }
}
