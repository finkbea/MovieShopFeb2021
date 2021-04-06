using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories {
    public class EFRepository<T> : IAsyncRepository<T> where T : class {
        protected readonly MovieShopDbContext _dbContext;
        
        public EFRepository(MovieShopDbContext dbContext) {
            _dbContext = dbContext;
        }
        public virtual async Task<T> GetByIdAsync(int id) {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }
        public virtual async Task<IEnumerable<T>> ListAllAsync() {
            /*var test = _dbContext / MovieShopDbContext.Where(m => m.Id == 2).FirstOrDefaultAsync();
            var testt = new List<MovieCardResponseModel>();
            var x = testt.Where(m => m.Id == 22).ToList();*/

            return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter) {
            //conditional
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }
        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null) {
            //filter = null means it can be null, if you pass nothing it will get the total count of that table
            if (filter != null) {
                return await _dbContext.Set<T>().Where(filter).CountAsync();
            }
            return await _dbContext.Set<T>().CountAsync();
        }
        public virtual async Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null) {
            //lets you know if a specific entry exists in the table
            if (filter != null) {
                return false;
            }
            return await _dbContext.Set<T>().Where(filter).AnyAsync();
        }
        public virtual async Task<T> AddAsync(T entity) {
            // Movie - Id, title, revenue, budget , 55
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<T> UpdateAsync(T entity) {
            // Disconnected way of doing things
            // Movie - Id, title, revenue, budget, 55
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public virtual async Task DeleteAsync(T entity) {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
