using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Interface
{
    public interface ICarRepository
    {
        Task AddCar(Car car);
        Task UpdateCar(Car car);

        Task<List<Car>> GetCars();
        
    }
}
