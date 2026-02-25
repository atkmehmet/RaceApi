using RaceApi.Application.Common;
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
        Task<Result<bool>> AddUser(User user);

        Task<Result<bool>> UpdateUser(User user);

        Task<Result<bool>> DeleteUser(int id);

        Task<Result<List<User>>> GetAllUsers();

        Task<Result<User?>> GetUserById(int id);
    }
}
