using RaceApi.Application.Common;
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
        Task<Result<bool>> AddPenalty(Penalties penalty);

        Task<Result<bool>> UpdatePenalty(Penalties penalty);

        

        Task<Result<List<Penalties>>> GetAllPenalties();

        
    }
}
