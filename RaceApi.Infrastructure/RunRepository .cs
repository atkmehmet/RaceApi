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
    public class RunRepository : IRunRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public RunRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Run>> GetAllAsync()
        {
            using var connection = _connectionFactory.Create();
            var sql = @"SELECT 
                        id,
                        event_id AS EventId,
                        run_number AS RunNumber,
                        status,
                        completed_at AS CompletedAt
                        FROM runs";

            return await connection.QueryAsync<Run>(sql);
        }

        public async Task<IEnumerable<Run>> GetByEventIdAsync(int eventId)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"SELECT 
                        id,
                        event_id AS EventId,
                        run_number AS RunNumber,
                        status,
                        completed_at AS CompletedAt
                        FROM runs
                        WHERE event_id = @EventId";

            return await connection.QueryAsync<Run>(sql, new { EventId = eventId });
        }

        public async Task<Run?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"SELECT 
                        id,
                        event_id AS EventId,
                        run_number AS RunNumber,
                        status,
                        completed_at AS CompletedAt
                        FROM runs
                        WHERE id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Run>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(Run run)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"INSERT INTO runs (event_id, run_number, status, completed_at)
                        VALUES (@EventId, @RunNumber, @Status, @CompletedAt)
                        RETURNING id;";

            return await connection.ExecuteScalarAsync<int>(sql, run);
        }

        public async Task<bool> UpdateAsync(Run run)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"UPDATE runs
                        SET event_id = @EventId,
                            run_number = @RunNumber,
                            status = @Status,
                            completed_at = @CompletedAt
                        WHERE id = @Id";

            var result = await connection.ExecuteAsync(sql, run);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _connectionFactory.Create();
            var sql = "DELETE FROM runs WHERE id = @Id";

            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}
