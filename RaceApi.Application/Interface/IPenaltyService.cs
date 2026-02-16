using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Interface
{
    public interface IPenaltyService
    {
        Task<IEnumerable<Penalties>> GetAllAsync();
        Task<Penalties> CreateAsync(Penalties penalties);
        Task UpdateAsync(Penalties penalties);
    }
}
