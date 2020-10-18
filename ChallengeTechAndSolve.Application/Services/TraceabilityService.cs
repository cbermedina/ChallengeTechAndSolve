namespace ChallengeTechAndSolve.Application.Services
{
    using ChallengeTechAndSolve.Application.Contracts.IServices;
    using ChallengeTechAndSolve.Business.Mappers;
    using ChallengeTechAndSolve.Business.Models;
    using ChallengeTechAndSolve.DataAccess.Contracts.IRepositories;
    using System.Threading.Tasks;

    public class TraceabilityService : ITraceabilityService
    {
        private readonly ITraceabilityRepository _traceabilityRepository;
        public TraceabilityService(ITraceabilityRepository traceabilityRepository)
        {
            _traceabilityRepository = traceabilityRepository;
        }
        public Task<int> AddAsync(TraceabilityDto traceabilityDto)
        {
          return  _traceabilityRepository.AddAsync(traceabilityDto.Map());
        }
    }
}
