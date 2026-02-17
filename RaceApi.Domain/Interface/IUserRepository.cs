using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Interface
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);

        Task<User?> GetById(int id);
        Task<User?> GetByUsername(string username);
        Task<List<User>> GetUsers();
    }
}
