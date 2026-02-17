using Dapper;
using RaceApi.Domain.Entities;
using RaceApi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace RaceApi.Infrastructure
{
    using Dapper;

    public class RoleRepository : IRoleRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public RoleRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        // ----------------------
        // ROLE METHODS
        // ----------------------

        public async Task AddRole(Role role)
        {
            var sql = @"INSERT INTO roles (name)
                    VALUES (@Name)
                    RETURNING id;";

            using var connection = _dbConnectionFactory.Create();
            var id = await connection.ExecuteScalarAsync<int>(sql, role);

            role.Id = id;
        }

        public async Task<List<Role>> GetRoles()
        {
            var sql = @"SELECT id, name
                    FROM roles
                    ORDER BY id;";

            using var connection = _dbConnectionFactory.Create();
            var roles = await connection.QueryAsync<Role>(sql);

            return roles.ToList();
        }

        public async Task UpdateRole(Role role)
        {
            var sql = @"UPDATE roles
                    SET name = @Name
                    WHERE id = @Id;";

            using var connection = _dbConnectionFactory.Create();
            await connection.ExecuteAsync(sql, role);
        }

        // ----------------------
        // ROLE PERMISSION METHODS
        // ----------------------

        public async Task AddPermissionToRole(RolePermission rolePermission)
        {
            var sql = @"INSERT INTO role_permissions (role_id, permission)
                    VALUES (@RoleId, @Permission)
                    RETURNING id;";

            using var connection = _dbConnectionFactory.Create();
            var id = await connection.ExecuteScalarAsync<int>(sql, rolePermission);

            rolePermission.Id = id;
        }

        public async Task<List<RolePermission>> GetRolePermissions(int roleId)
        {
            var sql = @"SELECT id,
                           role_id AS RoleId,
                           permission
                    FROM role_permissions
                    WHERE role_id = @RoleId
                    ORDER BY id;";

            using var connection = _dbConnectionFactory.Create();
            var result = await connection.QueryAsync<RolePermission>(sql, new { RoleId = roleId });

            return result.ToList();
        }
        public async Task RemovePermissionFromRole(int roleId, string permission)
        {
            var sql = @"DELETE FROM role_permissions
                WHERE role_id = @RoleId
                AND permission = @Permission;";

            using var connection = _dbConnectionFactory.Create();
            await connection.ExecuteAsync(sql, new
            {
                RoleId = roleId,
                Permission = permission
            });
        }

    }

}
