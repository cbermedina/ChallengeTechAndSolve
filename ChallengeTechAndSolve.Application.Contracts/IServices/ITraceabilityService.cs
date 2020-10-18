namespace ChallengeTechAndSolve.Application.Contracts.IServices
{
    using ChallengeTechAndSolve.Business.Models;
    using System.Threading.Tasks;
    public interface ITraceabilityService
    {
        Task<int> AddAsync(TraceabilityDto traceabilityDto);
    }
}
