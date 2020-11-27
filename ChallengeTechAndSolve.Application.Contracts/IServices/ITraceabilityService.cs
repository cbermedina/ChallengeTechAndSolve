namespace ChallengeTechAndSolve.Application.Contracts.IServices
{
    using ChallengeTechAndSolve.Business.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ITraceabilityService
    {
        Task<int> AddAsync(TraceabilityDto traceabilityDto);
        Task<List<TraceabilityDto>> GetAllAsync();
        Task<TraceabilityDto> GetByIdAsync(string id);
    }
}
