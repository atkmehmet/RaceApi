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
    public class RunLineRepository : IRunLineRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public RunLineRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<RunLine>> GetAllAsync()
        {
            using var connection = _connectionFactory.Create();
            var sql = @"SELECT
                    id,
                    run_id AS RunId,
                    lane_key AS LaneKey,
                    car_id AS CarId,
                    racer_name AS RacerName,
                    reaction_time_ms AS ReactionTimeMs,
                    elapsed_time_ms AS ElapsedTimeMs,
                    speed,
                    penalty_seconds AS PenaltySeconds,
                    final_time_ms AS FinalTimeMs,
                    winner
                    FROM run_lines";

            return await connection.QueryAsync<RunLine>(sql);
        }

        public async Task<IEnumerable<RunLine>> GetByRunIdAsync(int runId)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"SELECT
                    id,
                    run_id AS RunId,
                    lane_key AS LaneKey,
                    car_id AS CarId,
                    racer_name AS RacerName,
                    reaction_time_ms AS ReactionTimeMs,
                    elapsed_time_ms AS ElapsedTimeMs,
                    speed,
                    penalty_seconds AS PenaltySeconds,
                    final_time_ms AS FinalTimeMs,
                    winner
                    FROM run_lines
                    WHERE run_id = @RunId";

            return await connection.QueryAsync<RunLine>(sql, new { RunId = runId });
        }

        public async Task<RunLine?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"SELECT
                    id,
                    run_id AS RunId,
                    lane_key AS LaneKey,
                    car_id AS CarId,
                    racer_name AS RacerName,
                    reaction_time_ms AS ReactionTimeMs,
                    elapsed_time_ms AS ElapsedTimeMs,
                    speed,
                    penalty_seconds AS PenaltySeconds,
                    final_time_ms AS FinalTimeMs,
                    winner
                    FROM run_lines
                    WHERE id = @Id";

            return await connection.QueryFirstOrDefaultAsync<RunLine>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(RunLine runLine)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"INSERT INTO run_lines
                    (run_id, lane_key, car_id, racer_name,
                     reaction_time_ms, elapsed_time_ms,
                     speed, penalty_seconds, final_time_ms, winner)
                    VALUES
                    (@RunId, @LaneKey, @CarId, @RacerName,
                     @ReactionTimeMs, @ElapsedTimeMs,
                     @Speed, @PenaltySeconds, @FinalTimeMs, @Winner)
                    RETURNING id;";

            return await connection.ExecuteScalarAsync<int>(sql, runLine);
        }

        public async Task<bool> UpdateAsync(RunLine runLine)
        {
            using var connection = _connectionFactory.Create();
            var sql = @"UPDATE run_lines
                    SET run_id = @RunId,
                        lane_key = @LaneKey,
                        car_id = @CarId,
                        racer_name = @RacerName,
                        reaction_time_ms = @ReactionTimeMs,
                        elapsed_time_ms = @ElapsedTimeMs,
                        speed = @Speed,
                        penalty_seconds = @PenaltySeconds,
                        final_time_ms = @FinalTimeMs,
                        winner = @Winner
                    WHERE id = @Id";

            var result = await connection.ExecuteAsync(sql, runLine);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _connectionFactory.Create();
            var sql = "DELETE FROM run_lines WHERE id = @Id";

            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}
