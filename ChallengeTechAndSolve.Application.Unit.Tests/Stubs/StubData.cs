namespace ChallengeTechAndSolve.Application.Unit.Tests.Stubs
{
    using ChallengeTechAndSolve.DataAccess.Contracts.Entities;
    using System;
    using System.Collections.Generic;

    public static class StubData
    {
        public static TraceabilityEntity traceability_one = new TraceabilityEntity()
        {
            CreationDate = DateTime.Now,
            Document = "123456",
            TraceabilityId = new Guid("57d11393-c5af-4d53-82f9-13797e13b5c4")
        };
        public static TraceabilityEntity traceability_two = new TraceabilityEntity()
        {
            CreationDate = DateTime.Now,
            Document = "1234567",
            TraceabilityId = new Guid("803cdeae-95ff-4540-8508-cdbacbb9138f")
        };
        public static List<TraceabilityEntity> lstTraceability = new List<TraceabilityEntity>(new TraceabilityEntity[] {
            traceability_one,
            traceability_two
        });
    }
}
