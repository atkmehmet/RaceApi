using RaceApi.Application.Common;
using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace RaceApi.Application.Interface
{
    public interface ICarService
    {
        Task<Result<List<Car>>> GetAllCars();

        Task<Result<Car>> AddCar(Car car);
    }
}
