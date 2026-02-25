using RaceApi.Application.Common;
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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Result<bool>> AddEvent(Event eventEntity)
        {
            try
            {
                await _eventRepository.CreateAsync(eventEntity);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Failure<bool>(ex, "AddEvent");
            }
        }

        public async Task<Result<bool>> UpdateEvent(Event eventEntity)
        {
            try
            {
                await _eventRepository.UpdateAsync(eventEntity);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Failure<bool>(ex, "UpdateEvent");
            }
        }

        public async Task<Result<bool>> DeleteEvent(int id)
        {
            try
            {
                await _eventRepository.DeleteAsync(id);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Failure<bool>(ex, "DeleteEvent");
            }
        }

        public async Task<Result<List<Event>>> GetAllEvents()
        {
            try
            {
                var result = await _eventRepository.GetAllAsync();
                return Result<List<Event>>.Success(result.ToList());
            }
            catch (Exception ex)
            {
                return Failure<List<Event>>(ex, "GetAllEvents");
            }
        }

        public async Task<Result<Event?>> GetEventById(int id)
        {
            try
            {
                var result = await _eventRepository.GetByIdAsync(id);
                return Result<Event?>.Success(result);
            }
            catch (Exception ex)
            {
                return Failure<Event?>(ex, "GetEventById");
            }
        }

        private Result<T> Failure<T>(Exception ex, string field)
        {
            return Result<T>.Failure(new List<ValidationError>
        {
            new ValidationError
            {
                errorMessage = ex.Message,
                fieldName = field
            }
        });
        }
    }
}
