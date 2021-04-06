using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces {
    public interface IAsyncRepository<T> where T: class { //generic constraints
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter); //conditional
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null); //filter = null means it can be null, if you pass nothing it will get the total count of that table
        Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter = null); //lets you know if a specific entry exists in the table
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity); //remove <T> if it shouldn't return anything

        /*Task<PaginatedList<T>> GetPagedData(int pageIndex, int pageSize,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderedQuery = null,
        Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);*/
    }
}
