using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event?> GetByIdAsync(int id);
        Task<int> CreateAsync(Event eventEntity);
        Task<bool> UpdateAsync(Event eventEntity);
        Task<bool> DeleteAsync(int id);
    }
}
