namespace ChallengeTechAndSolve.DataAccess.Repositories
{
    using ChallengeTechAndSolve.DataAccess.Contracts;
    using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
    using ChallengeTechAndSolve.DataAccess.Contracts.IRepositories;
    using System.Threading.Tasks;
    public class TraceabilityRepository : ITraceabilityRepository
    {
        #region properties
        private readonly IChallengeTechAndSolveDBContext _challengeTechAndSolveDBContext;
        #endregion

        #region Constructor
        public TraceabilityRepository(IChallengeTechAndSolveDBContext challengeTechAndSolveDBContext)
        {
            _challengeTechAndSolveDBContext = challengeTechAndSolveDBContext;
        }
        #endregion

        #region Methods
        public async Task<int> AddAsync(TraceabilityEntity model)
        {
            await _challengeTechAndSolveDBContext.TraceabilityEntities.AddAsync(model);
            int result = await _challengeTechAndSolveDBContext.SaveChangesAsync();
            return result;
        }
        #endregion
    }
}
