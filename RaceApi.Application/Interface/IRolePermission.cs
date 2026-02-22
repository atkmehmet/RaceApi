using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Interface
{
    public interface IRolePermission
    {
        Task AddRolePermission(RolePermission rolePermission);

        Task RemoveRolePermission(RolePermission rolePermission);

        Task<RolePermission> GetRolePermission(RolePermission rolePermission);

        Task<List<RolePermission>> GetAllPermission();
    }
}
