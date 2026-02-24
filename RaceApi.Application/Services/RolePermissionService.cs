using RaceApi.Application.Common;
using RaceApi.Application.Interface;
using RaceApi.Domain.Entities;
using RaceApi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRoleRepository _roleRepository;


        public RolePermissionService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Result<Boolean>> AddRolePermission(RolePermission rolePermission)
        {
            try
            {
                await _roleRepository.AddPermissionToRole(rolePermission);
                return Result<Boolean>.Success(true);
            }
            catch (Exception ex)
            {
                var message = new ValidationError { errorMessage = ex.Message, fieldName = "trycatch" };



                return Result<Boolean>.Failure(new List<ValidationError> { message });
            }

        }

        public async Task<Result<List<RolePermission>>> GetAllPermission(int roleId)
        {
            try
            {

                var result = await _roleRepository.GetRolePermissions(roleId);

                return Result<List<RolePermission>>.Success(result);

            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError { errorMessage = ex.ToString(), fieldName = "trycatch" });
                return Result<List<RolePermission>>.Failure(errors);
            }
        }

        public async Task<Result<bool>> AddRole(Role role)
        {
            try
            {
                await _roleRepository.AddRole(role);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError { errorMessage = ex.ToString(), fieldName = "trycacth" });
                return Result<bool>.Failure(errors);
            }

        }

        public async Task<Result<List<Role>>> GetAllRole()
        {
            try
            {
                var result = await _roleRepository.GetRoles();

                return Result<List<Role>>.Success(result);
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError { errorMessage = ex.ToString(), fieldName = "trycacth" });
                return Result<List<Role>>.Failure(errors);
            }
        }

        public async Task<Result<bool>> RemoveRolePermission(int roleId, string permssion)
        {
            try
            {
                await _roleRepository.RemovePermissionFromRole(roleId, permssion);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError { errorMessage = ex.ToString(), fieldName = "trycacth" });

                return Result<bool>.Failure(errors);
            }
        }

        public async Task<Result<bool>> UpdateRole(Role role)
        {
            try
            {
                await _roleRepository.UpdateRole(role);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError
                {
                    errorMessage = ex.ToString(),
                    fieldName = "trycacth"
                });
                return Result<bool>.Failure(errors);
            }
        }
    }
}
