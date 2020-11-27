namespace ChallengeTechAndSolve.Application.Services
{
    using ChallengeTechAndSolve.Application.Contracts.IServices;
    using ChallengeTechAndSolve.Business.Mappers;
    using ChallengeTechAndSolve.Business.Models;
    using ChallengeTechAndSolve.DataAccess.Contracts.IRepositories;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TraceabilityService : ITraceabilityService
    {
        private readonly ITraceabilityRepository _traceabilityRepository;
        public TraceabilityService(ITraceabilityRepository traceabilityRepository)
        {
            _traceabilityRepository = traceabilityRepository;
        }
        public async Task<TraceabilityDto> AddAsync(TraceabilityDto traceabilityDto)
        {
            await _traceabilityRepository.AddAsync(traceabilityDto.Map());
            return traceabilityDto;
        }

        public async Task<List<TraceabilityDto>> GetAllAsync()
        {
            var result = await _traceabilityRepository.GetAllAsync();
            return result.Select(s => s.Map()).ToList();
        }

        public async Task<TraceabilityDto> GetByIdAsync(string id)
        {
            return (await _traceabilityRepository.GetByIdAsync(id)).Map();
        }
    }
}
