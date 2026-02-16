using RaceApi.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using RaceApi.Domain.Interface;
using RaceApi.Domain.Entities;

namespace RaceApi.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _repository.GetCars();
        }

        public async Task<Car> CreateAsync(Car car)
        {
            try {
                if (string.IsNullOrWhiteSpace(car.plate))
                    throw new Exception("Plate boş olamaz");

                await _repository.AddCar(car);

                return car;
            }
            catch (Exception ex) {
                throw new Exception();
            }
            // Basit iş kuralı örneği

        }
    }
}
