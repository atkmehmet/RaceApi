using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Domain.Interface
{
    public interface IRoleRepository
    {
        // Role işlemleri
        Task AddRole(Role role);
        Task UpdateRole(Role role);
        Task<List<Role>> GetRoles();

        // RolePermission işlemleri
        Task AddPermissionToRole(RolePermission rolePermission);
        Task RemovePermissionFromRole(int roleId, string permission);
        Task<List<RolePermission>> GetRolePermissions(int roleId);
    }
}
