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

        public async Task<IEnumerable<Penalties>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Penalties> CreateAsync(Penalties penalties)
        {
            try
            {
                // 🔹 Basit Business Rules

                if (penalties.runId <= 0)
                    throw new Exception("RunId 0'dan büyük olmalı");

                if (penalties.timePenalty < 0)
                    throw new Exception("Time penalty negatif olamaz");

                await _repository.AddPenalty(penalties);

                return penalties;
            }
            catch (Exception)
            {
                throw; // hatayı ezmeyelim
            }
        }

        public async Task UpdateAsync(Penalties penalties)
        {
            try
            {
                if (penalties.id <= 0)
                    throw new Exception("Geçersiz Id");

                if (penalties.timePenalty < 0)
                    throw new Exception("Time penalty negatif olamaz");

                await _repository.UpdatePenalty(penalties);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
