using RaceApi.Application.Common;
using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Interface
{
    public interface IRolePermissionService
    {
        Task<Result<Boolean>> AddRolePermission(RolePermission rolePermission);

        Task<Result<Boolean>> AddRole(Role role);

        

        Task<Result<Boolean>> UpdateRole(Role role);

        Task<Result<List<RolePermission>>> GetAllPermission(int roleId);

        Task<Result<List<Role>>> GetAllRole();
        Task<Result<Boolean>> RemoveRolePermission(int roleId,string permssion);

        


    }
}
