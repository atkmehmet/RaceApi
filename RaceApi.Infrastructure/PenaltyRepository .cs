using Dapper;
using RaceApi.Domain.Entities;
using RaceApi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Infrastructure
{
    public class PenaltyRepository : IPenaltyRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public PenaltyRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddPenalty(Penalties penalties)
        {
            const string sql = """
            INSERT INTO penalties (run_id, type, time_penalty, disqualified)
            VALUES (@runId, @type, @timePenalty, @disqualified)
        """;

            using var connection = _connectionFactory.Create();
            await connection.ExecuteAsync(sql, penalties);
        }

        public async Task UpdatePenalty(Penalties penalties)
        {
            const string sql = """
            UPDATE penalties
            SET run_id = @runId,
                type = @type,
                time_penalty = @timePenalty,
                disqualified = @disqualified
            WHERE id = @id
        """;

            using var connection = _connectionFactory.Create();
            await connection.ExecuteAsync(sql, penalties);
        }

        public async Task<List<Penalties>> GetAll()
        {
            const string sql = """
            SELECT 
                id,
                run_id AS runId,
                type,
                time_penalty AS timePenalty,
                disqualified
            FROM penalties
        """;

            using var connection = _connectionFactory.Create();
            var result = await connection.QueryAsync<Penalties>(sql);
            return result.ToList();
        }
    }

}
