using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using RaceApi.Domain.Entities;
using RaceApi.Domain.Interface;

namespace RaceApi.Infrastructure
{
    
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public UserRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task AddUser(User user)
        {
            var sql = @"INSERT INTO users (username, password_hash, role_id)
                    VALUES (@Username, @PasswordHash, @RoleId)
                    RETURNING id;";

            using var connection = _dbConnectionFactory.Create();
            var id = await connection.ExecuteScalarAsync<int>(sql, user);

            user.Id = id;
        }

        public async Task UpdateUser(User user)
        {
            var sql = @"UPDATE users
                    SET username = @Username,
                        password_hash = @PasswordHash,
                        role_id = @RoleId
                    WHERE id = @Id;";

            using var connection = _dbConnectionFactory.Create();
            await connection.ExecuteAsync(sql, user);
        }

        public async Task DeleteUser(int id)
        {
            var sql = @"DELETE FROM users
                    WHERE id = @Id;";

            using var connection = _dbConnectionFactory.Create();
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<User?> GetById(int id)
        {
            var sql = @"SELECT id,
                           username,
                           password_hash AS PasswordHash,
                           role_id AS RoleId
                    FROM users
                    WHERE id = @Id;";

            using var connection = _dbConnectionFactory.Create();
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<User?> GetByUsername(string username)
        {
            var sql = @"SELECT id,
                           username,
                           password_hash AS PasswordHash,
                           role_id AS RoleId
                    FROM users
                    WHERE username = @Username;";

            using var connection = _dbConnectionFactory.Create();
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });
        }

        public async Task<List<User>> GetUsers()
        {
            var sql = @"SELECT id,
                           username,
                           password_hash AS PasswordHash,
                           role_id AS RoleId
                    FROM users
                    ORDER BY id;";

            using var connection = _dbConnectionFactory.Create();
            var users = await connection.QueryAsync<User>(sql);

            return users.ToList();
        }
    }

}
