namespace ChallengeTechAndSolve.DataAccess.EntityConfig
{
    using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class TraceabilityEntityConfig
    {

        public static void SetEntityBuilder(EntityTypeBuilder<TraceabilityEntity> entityBuilder)
        {

            entityBuilder.ToTable("Traceability");
            entityBuilder.HasKey(x => x.TraceabilityId);
            entityBuilder.Property(x => x.Document).IsRequired();
            entityBuilder.Property(x => x.CreationDate).IsRequired();
        }
    }
}
