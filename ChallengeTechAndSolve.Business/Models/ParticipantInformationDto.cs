namespace ChallengeTechAndSolve.Business.Models
{
    using Microsoft.AspNetCore.Http;
    public class ParticipantInformationDto
    {
        /// <summary>
        /// Participant document
        /// </summary>
        public string Document { get; set; }
        /// <summary>
        /// Information file
        /// </summary>
        public IFormFile FileInfo { get; set; }
    }
}
