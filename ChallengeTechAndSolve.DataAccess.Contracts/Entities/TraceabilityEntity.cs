namespace ChallengeTechAndSolve.DataAccess.Contracts.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class TraceabilityEntity
    {
        public Guid TraceabilityId { get; set; }
        public string Document { get; set; }
        public DateTime CreationDate { get; set; }
    }

}
