using RaceApi.Application.Common;
using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Interface
{
    public interface IEventService
    {
        Task<Result<bool>> AddEvent(Event eventEntity);

        Task<Result<bool>> UpdateEvent(Event eventEntity);

        Task<Result<bool>> DeleteEvent(int id);

        Task<Result<List<Event>>> GetAllEvents();

        Task<Result<Event?>> GetEventById(int id);
    }
}
