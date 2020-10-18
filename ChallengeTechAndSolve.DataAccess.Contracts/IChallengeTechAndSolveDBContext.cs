namespace ChallengeTechAndSolve.DataAccess.Contracts
{
    using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IChallengeTechAndSolveDBContext
    {
        DbSet<TraceabilityEntity> TraceabilityEntities { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
