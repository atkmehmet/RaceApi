using RaceApi.Application.Common;
using RaceApi.Application.Interface;
using RaceApi.Domain.Entities;
using RaceApi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Car>>> GetAllCars()
        {
            try
            {
                var cars = await _repository.GetCars();
                return Result<List<Car>>.Success(cars.ToList());
            }
            catch (Exception ex)
            {
                return Result<List<Car>>.Failure(new List<ValidationError>
            {
                new ValidationError { fieldName = "GetAllCars", errorMessage = ex.Message }
            });
            }
        }

        public async Task<Result<Car>> AddCar(Car car)
        {
            try
            {
              

                await _repository.AddCar(car);
                return Result<Car>.Success(car);
            }
            catch (Exception ex)
            {
                return Result<Car>.Failure(new List<ValidationError>
            {
                new ValidationError { fieldName = "AddCar", errorMessage = ex.Message }
            });
            }
        }
    }
}
