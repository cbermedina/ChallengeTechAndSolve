namespace ChallengeTechAndSolve.DataAccess.Repositories
{
    using ChallengeTechAndSolve.DataAccess.Contracts;
    using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
    using ChallengeTechAndSolve.DataAccess.Contracts.IRepositories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
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
        public async Task<TraceabilityEntity> AddAsync(TraceabilityEntity model)
        {
            await _challengeTechAndSolveDBContext.TraceabilityEntities.AddAsync(model);
            int result = await _challengeTechAndSolveDBContext.SaveChangesAsync();
            return model;
        }
        public async Task<List<TraceabilityEntity>> GetAllAsync()
        {
            return await  _challengeTechAndSolveDBContext.TraceabilityEntities.ToListAsync();
        }
        public async Task<TraceabilityEntity> GetByIdAsync(string id)
        {
            return await _challengeTechAndSolveDBContext.TraceabilityEntities.FirstOrDefaultAsync(w=>w.Document==id);
        }
        #endregion
    }
}
