using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Interface
{
    public interface IRunRepository
    {
        Task<IEnumerable<Run>> GetAllAsync();
        Task<IEnumerable<Run>> GetByEventIdAsync(int eventId);
        Task<Run?> GetByIdAsync(int id);
        Task<int> CreateAsync(Run run);
        Task<bool> UpdateAsync(Run run);
        Task<bool> DeleteAsync(int id);
    }
}
