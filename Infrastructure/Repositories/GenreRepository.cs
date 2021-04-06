using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using ApplicationCore.Entities;

namespace Infrastructure.Repositories {
    public class GenreRepository : EFRepository<Genre> {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext) {
        }
        //defunct
        public async override Task<Genre> GetByIdAsync(int id) {
            return await _dbContext.Genres.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
