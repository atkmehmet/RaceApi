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
    public class PenaltyService : IPenaltyService
    {
        private readonly IPenaltyRepository _repository;

        public PenaltyService(IPenaltyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Penalties>>> GetAllPenalties()
        {
            try
            {
                var result = await _repository.GetAll();
                return Result<List<Penalties>>.Success(result.ToList());
            }
            catch (Exception ex)
            {
                return Failure<List<Penalties>>(ex, "GetAllPenalties");
            }
        }

        
        public async Task<Result<bool>> AddPenalty(Penalties penalties)
        {
            try
            {
                // 🔹 Business Rules
                if (penalties.runId <= 0)
                    return Result<bool>.Failure(new List<ValidationError>
                {
                    new ValidationError { fieldName = "runId", errorMessage = "RunId 0'dan büyük olmalı" }
                });

                if (penalties.timePenalty < 0)
                    return Result<bool>.Failure(new List<ValidationError>
                {
                    new ValidationError { fieldName = "timePenalty", errorMessage = "Time penalty negatif olamaz" }
                });

                await _repository.AddPenalty(penalties);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Failure<bool>(ex, "AddPenalty");
            }
        }

        public async Task<Result<bool>> UpdatePenalty(Penalties penalties)
        {
            try
            {
                // 🔹 Business Rules
                if (penalties.id <= 0)
                    return Result<bool>.Failure(new List<ValidationError>
                {
                    new ValidationError { fieldName = "id", errorMessage = "Geçersiz Id" }
                });

                if (penalties.timePenalty < 0)
                    return Result<bool>.Failure(new List<ValidationError>
                {
                    new ValidationError { fieldName = "timePenalty", errorMessage = "Time penalty negatif olamaz" }
                });

                await _repository.UpdatePenalty(penalties);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Failure<bool>(ex, "UpdatePenalty");
            }
        }

    
        // 🔹 Private Error Helper
        private Result<T> Failure<T>(Exception ex, string field)
        {
            return Result<T>.Failure(new List<ValidationError>
        {
            new ValidationError { fieldName = field, errorMessage = ex.Message }
        });
        }
    }

}
