namespace ChallengeTechAndSolve.Application.Contracts.IServices
{
    using ChallengeTechAndSolve.Business.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    public interface IProcessInformationService
    {
        Task<FileStreamResult> Process(ParticipantInformationDto participantInformationDto);
    }
}
