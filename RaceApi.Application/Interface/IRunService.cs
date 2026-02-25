using RaceApi.Application.Common;
using RaceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceApi.Application.Interface
{
    public interface IRunService
    {
        Task<Result<bool>> AddRun(Run run);

        Task<Result<bool>> UpdateRun(Run run);

        Task<Result<bool>> DeleteRun(int id);

        Task<Result<List<Run>>> GetAllRuns();

        Task<Result<List<Run>>> GetRunsByEventId(int eventId);

        Task<Result<Run>> GetRunById(int id);
    }
}
