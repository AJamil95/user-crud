using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using user_crud.Server.Entities;

namespace user_crud.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<(IEnumerable<User> Items, int TotalCount)> GetPaginatedAsync(int pageNumber, int pageSize);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
