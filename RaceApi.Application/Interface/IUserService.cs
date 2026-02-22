using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Interface
{
    public interface IUserService
    {
        Task AddUser(User user);

        Task DeleteUser(User user);

        Task UpdateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();

    }
}
