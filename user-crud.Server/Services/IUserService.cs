using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using user_crud.Server.Dto;

namespace user_crud.Server.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserDto dto);
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<Dto.PaginatedResult<UserDto>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task UpdateAsync(UserDto dto);
        Task DeleteAsync(Guid id);
    }
}
