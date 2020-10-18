namespace ChallengeTechAndSolve.DataAccess
{
    using ChallengeTechAndSolve.DataAccess.Contracts;
    using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
    using ChallengeTechAndSolve.DataAccess.EntityConfig;
    using Microsoft.EntityFrameworkCore;
    public class ChallengeTechAndSolveDBContext : DbContext, IChallengeTechAndSolveDBContext
    {
        public DbSet<TraceabilityEntity> TraceabilityEntities { get; set; }

        public ChallengeTechAndSolveDBContext(DbContextOptions options) : base(options) { }
        public ChallengeTechAndSolveDBContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TraceabilityEntityConfig.SetEntityBuilder(modelBuilder.Entity<TraceabilityEntity>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
