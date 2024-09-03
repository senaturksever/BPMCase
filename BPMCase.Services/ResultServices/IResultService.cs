using BPMCase.Entities.Dtos.ResultDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMCase.Services.ResultServices
{
    public interface IResultService
    {
        Task<ResultPageModel> GetResultPageAsync(Guid workflowId);
    }
}
