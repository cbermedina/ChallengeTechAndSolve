namespace ChallengeTechAndSolve.Business.Mappers
{
    using ChallengeTechAndSolve.Business.Models;
    using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
    using System;

    public static class TraceabilityMapper
    {
        public static TraceabilityDto Map(this TraceabilityEntity dto)
        {
            return new TraceabilityDto()
            {
                CreationDate = dto.CreationDate,
                Document = dto.Document,
                TraceabilityId = dto.TraceabilityId,
            };
        }

        public static TraceabilityEntity Map(this TraceabilityDto entity)
        {
            return new TraceabilityEntity()
            {
                CreationDate = entity.CreationDate,
                Document = entity.Document,
                TraceabilityId = entity.TraceabilityId,
            };
        }
        public static TraceabilityEntity Map(this ParticipantInformationDto entity)
        {
            return new TraceabilityEntity()
            {
                CreationDate = DateTime.Now,
                Document = entity.Document,
                TraceabilityId = Guid.NewGuid(),
            };
        }
    }
}
