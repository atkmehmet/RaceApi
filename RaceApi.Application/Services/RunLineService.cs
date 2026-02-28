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
    public class RunLineService : IRunLineService
    {
        private readonly IRunLineRepository _runLineRepository;

        public RunLineService(IRunLineRepository runLineRepository)
        {
            _runLineRepository = runLineRepository;
        }

        public async Task<Result<bool>> AddRunLine(RunLine runLine)
        {
            try
            {
                await _runLineRepository.CreateAsync(runLine);
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

        public async Task<Result<bool>> UpdateRunLine(RunLine runLine)
        {
            try
            {
                await _runLineRepository.UpdateAsync(runLine);
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

        public async Task<Result<bool>> DeleteRunLine(int id)
        {
            try
            {
                await _runLineRepository.DeleteAsync(id);
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

        public async Task<Result<List<RunLine>>> GetAllRunLines()
        {
            try
            {
                var result = await _runLineRepository.GetAllAsync();
                return Result<List<RunLine>>.Success(result.ToList());
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

                return Result<List<RunLine>>.Failure(errors);
            }
        }

        public async Task<Result<List<RunLine>>> GetRunLinesByRunId(int runId)
        {
            try
            {
                var result = await _runLineRepository.GetByRunIdAsync(runId);
                return Result<List<RunLine>>.Success(result.ToList());
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

                return Result<List<RunLine>>.Failure(errors);
            }
        }

        public async Task<Result<RunLine>> GetRunLineById(int id)
        {
            try
            {
                var result = await _runLineRepository.GetByIdAsync(id);

                if (result == null)
                {
                    return Result<RunLine>.Failure(new List<ValidationError>
                {
                    new ValidationError
                    {
                        errorMessage = "RunLine not found",
                        fieldName = "id"
                    }
                });
                }

                return Result<RunLine>.Success(result);
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

                return Result<RunLine>.Failure(errors);
            }
        }
    }
}
