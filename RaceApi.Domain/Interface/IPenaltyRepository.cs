using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Interface
{
    public interface IPenaltyRepository
    {
        Task<List<Penalties>> GetAll();
        Task AddPenalty(Penalties penalties);

        Task UpdatePenalty(Penalties penalties);
    }
}
