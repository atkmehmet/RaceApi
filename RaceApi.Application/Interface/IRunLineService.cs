using RaceApi.Application.Common;
using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Interface
{
    public interface IRunLineService
    {
        Task<Result<bool>> AddRunLine(RunLine runLine);

        Task<Result<bool>> UpdateRunLine(RunLine runLine);

        Task<Result<bool>> DeleteRunLine(int id);

        Task<Result<List<RunLine>>> GetAllRunLines();

        Task<Result<List<RunLine>>> GetRunLinesByRunId(int runId);

        Task<Result<RunLine>> GetRunLineById(int id);
    }
}
