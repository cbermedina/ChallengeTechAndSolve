namespace ChallengeTechAndSolve.Application.Services
{
    using ChallengeTechAndSolve.Application.Contracts.IServices;
    using ChallengeTechAndSolve.Business;
    using ChallengeTechAndSolve.Business.Mappers;
    using ChallengeTechAndSolve.Business.Models;
    using ChallengeTechAndSolve.Common.Constants;
    using ChallengeTechAndSolve.DataAccess.Contracts.IRepositories;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Threading.Tasks;
    public class ProcessInformationService : ProcessFile, IProcessInformationService
    {
        private readonly ITraceabilityRepository _traceabilityRepository;
        public ProcessInformationService(ITraceabilityRepository traceabilityRepository)
        {
            _traceabilityRepository = traceabilityRepository;
        }
        /// <summary>
        /// Process information
        /// </summary>
        /// <param name="participantInformationDto"></param>
        /// <returns></returns>
        public async Task<FileStreamResult> Process(ParticipantInformationDto participantInformationDto)
        {
            await _traceabilityRepository.AddAsync(participantInformationDto.Map());
            MemoryStream resultProcess = await FileProcess(participantInformationDto);
            var result = new FileStreamResult(resultProcess, "text/plain") { FileDownloadName = CommonInformation.FileOutPut };
            return result;
        }
    }
}
