namespace ChallengeTechAndSolve.Business.Models
{
    using System;
    public class TraceabilityDto
    {
        public Guid TraceabilityId { get; set; }
        public string Document { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
