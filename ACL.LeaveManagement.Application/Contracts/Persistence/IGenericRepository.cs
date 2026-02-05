using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACL.LeaveManagement.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task<bool> Exists(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
