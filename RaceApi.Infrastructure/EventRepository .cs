using RaceApi.Domain.Entities;
using RaceApi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace RaceApi.Infrastructure
{
    public class EventRepository : IEventRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public EventRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            using var connection = _connectionFactory.Create();
            var sql = "SELECT id, name, date, is_live AS IsLive FROM events";
            return await connection.QueryAsync<Event>(sql);
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.Create();
            var sql = "SELECT id, name, date, is_live AS IsLive FROM events WHERE id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Event>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(Event eventEntity)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"INSERT INTO events (name, date, is_live) 
                        VALUES (@Name, @Date, @IsLive)
                        RETURNING id;";
            return await connection.ExecuteScalarAsync<int>(sql, eventEntity);
        }

        public async Task<bool> UpdateAsync(Event eventEntity)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"UPDATE events 
                        SET name = @Name,
                            date = @Date,
                            is_live = @IsLive
                        WHERE id = @Id";

            var result = await connection.ExecuteAsync(sql, eventEntity);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _connectionFactory.Create();
            var sql = "DELETE FROM events WHERE id = @Id";
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}
