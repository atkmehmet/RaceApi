using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Runtime.ConstrainedExecution;
using RaceApi.Domain.Entities;
using RaceApi.Domain.Interface;

namespace RaceApi.Infrastructure
{

    public class CarRepository : ICarRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public CarRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddCar(Car car)
        {
            const string sql = """
            INSERT INTO cars (plate, driver_name, car_class)
            VALUES (@Plate, @DriverName, @CarClass)
        """;

            using var connection = _connectionFactory.Create();
            await connection.ExecuteAsync(sql, car);
        }

        public async Task UpdateCar(Car car)
        {
            const string sql = """
            UPDATE cars
            SET plate = @Plate,
                driver_name = @DriverName,
                car_class = @CarClass
            WHERE id = @Id
        """;

            using var connection = _connectionFactory.Create();
            await connection.ExecuteAsync(sql, car);
        }

        public async Task<List<Car>> GetCars()
        {
            const string sql = """
            SELECT 
                id,
                plate AS Plate,
                driver_name AS DriverName,
                car_class AS CarClass
            FROM cars
        """;

            using var connection = _connectionFactory.Create();
            var result = await connection.QueryAsync<Car>(sql);
            return result.ToList();
        }
    }

}
