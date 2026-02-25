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
    public class RunService : IRunService
    {
        private readonly IRunRepository _runRepository;

        public RunService(IRunRepository runRepository)
        {
            _runRepository = runRepository;
        }

        public async Task<Result<bool>> AddRun(Run run)
        {
            try
            {
                await _runRepository.CreateAsync(run);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>
            {
                new ValidationError
                {
                    errorMessage = ex.ToString(),
                    fieldName = "trycatch"
                }
            };

                return Result<bool>.Failure(errors);
            }
        }

        public async Task<Result<bool>> UpdateRun(Run run)
        {
            try
            {
                await _runRepository.UpdateAsync(run);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>
            {
                new ValidationError
                {
                    errorMessage = ex.ToString(),
                    fieldName = "trycatch"
                }
            };

                return Result<bool>.Failure(errors);
            }
        }

        public async Task<Result<bool>> DeleteRun(int id)
        {
            try
            {
                await _runRepository.DeleteAsync(id);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>
            {
                new ValidationError
                {
                    errorMessage = ex.ToString(),
                    fieldName = "trycatch"
                }
            };

                return Result<bool>.Failure(errors);
            }
        }

        public async Task<Result<List<Run>>> GetAllRuns()
        {
            try
            {
                var result = await _runRepository.GetAllAsync();
                return Result<List<Run>>.Success(result.ToList());
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>
            {
                new ValidationError
                {
                    errorMessage = ex.ToString(),
                    fieldName = "trycatch"
                }
            };

                return Result<List<Run>>.Failure(errors);
            }
        }

        public async Task<Result<List<Run>>> GetRunsByEventId(int eventId)
        {
            try
            {
                var result = await _runRepository.GetByEventIdAsync(eventId);
                return Result<List<Run>>.Success(result.ToList());
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>
            {
                new ValidationError
                {
                    errorMessage = ex.ToString(),
                    fieldName = "trycatch"
                }
            };

                return Result<List<Run>>.Failure(errors);
            }
        }

        public async Task<Result<Run>> GetRunById(int id)
        {
            try
            {
                var result = await _runRepository.GetByIdAsync(id);

                if (result == null)
                {
                    return Result<Run>.Failure(new List<ValidationError>
                {
                    new ValidationError
                    {
                        errorMessage = "Run not found",
                        fieldName = "id"
                    }
                });
                }

                return Result<Run>.Success(result);
            }
            catch (Exception ex)
            {
                var errors = new List<ValidationError>
            {
                new ValidationError
                {
                    errorMessage = ex.ToString(),
                    fieldName = "trycatch"
                }
            };

                return Result<Run>.Failure(errors);
            }
        }
    }
}
