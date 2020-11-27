using ChallengeTechAndSolve.Application.Unit.Tests.Stubs;
using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
using ChallengeTechAndSolve.DataAccess.Contracts.IRepositories;
using Moq;

namespace ChallengeTechAndSolve.Application.Unit.Tests.MockRepository
{
    public class RaceabilityRepositoryMock
    {
        public Mock<ITraceabilityRepository> _traceabilityRepository { get; set; }
        public RaceabilityRepositoryMock()
        {
            _traceabilityRepository = new Mock<ITraceabilityRepository>();
            Setpp();
        }
        private void Setpp()
        {
            _traceabilityRepository.Setup(x => x.AddAsync(It.IsAny<TraceabilityEntity>())).ReturnsAsync(StubData.traceability_one);
            _traceabilityRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(StubData.traceability_one);
            _traceabilityRepository.Setup(x => x.GetByIdAsync("1234567")).ReturnsAsync(StubData.traceability_two);
            _traceabilityRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(StubData.lstTraceability);
        }
    }
}
