using RaceApi.Application.Interface;
using RaceApi.Domain.Entities;
using RaceApi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;   
        }
       public async Task  AddUser(User user)
        {
           await _userRepository.AddUser(user);
            
        }

      public async  Task DeleteUser(User user)
        {
            await _userRepository.DeleteUser(user.Id);

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
          return   await _userRepository.GetUsers();
        }

       public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
            
        }
    }
}
