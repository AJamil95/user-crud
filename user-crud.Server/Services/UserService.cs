using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_crud.Server.Dto;
using user_crud.Server.Entities;
using user_crud.Server.Repositories;

namespace user_crud.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserDto> CreateAsync(UserDto dto)
        {
            var entity = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Profession = dto.Profession,
                Nationality = dto.Nationality,
                Phone = dto.Phone,
                Email = dto.Email,
                Salary = dto.Salary
            };

            var created = await _repo.AddAsync(entity);
            dto.Id = created.Id;
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                BirthDate = u.BirthDate,
                Profession = u.Profession,
                Nationality = u.Nationality,
                Phone = u.Phone,
                Email = u.Email,
                Salary = u.Salary
            });
        }

        public async Task<Dto.PaginatedResult<UserDto>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            var (items, total) = await _repo.GetPaginatedAsync(pageNumber, pageSize);
            var dtos = items.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                BirthDate = u.BirthDate,
                Profession = u.Profession,
                Nationality = u.Nationality,
                Phone = u.Phone,
                Email = u.Email,
                Salary = u.Salary
            });

            return new Dto.PaginatedResult<UserDto>
            {
                Items = dtos,
                TotalCount = total,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u == null) return null;
            return new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                BirthDate = u.BirthDate,
                Profession = u.Profession,
                Nationality = u.Nationality,
                Phone = u.Phone,
                Email = u.Email,
                Salary = u.Salary
            };
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var entity = new User
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Profession = dto.Profession,
                Nationality = dto.Nationality,
                Phone = dto.Phone,
                Email = dto.Email,
                Salary = dto.Salary
            };

            await _repo.UpdateAsync(entity);
        }
    }
}
