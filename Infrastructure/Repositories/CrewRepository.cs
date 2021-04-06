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
    public class CrewRepository : EFRepository<Crew> {
        public CrewRepository(MovieShopDbContext dbContext) : base(dbContext) {
        }


        public async override Task<Crew> GetByIdAsync(int id) {
            return await _dbContext.Crews.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
