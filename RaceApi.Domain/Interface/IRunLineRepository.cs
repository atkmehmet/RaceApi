using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Interface
{
    public interface IRunLineRepository
    {
        Task<int> CreateAsync(RunLine runLine);

        Task<bool> UpdateAsync(RunLine runLine);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<RunLine>> GetAllAsync();

        Task<IEnumerable<RunLine>> GetByRunIdAsync(int runId);

        Task<RunLine?> GetByIdAsync(int id);
    }
}
