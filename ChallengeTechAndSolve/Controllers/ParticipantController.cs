namespace ChallengeTechAndSolve.Controllers
{
    using ChallengeTechAndSolve.Application.Contracts.IServices;
    using ChallengeTechAndSolve.Mappers;
    using ChallengeTechAndSolve.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    /// <summary>
    /// Participant controller
    /// </summary>
    [ApiController]
    //[ApiExplorerSettings(GroupName = "v1")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        #region Properties
        private readonly IProcessInformationService _fileProcessService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileProcessService"></param>
        public ParticipantController(IProcessInformationService fileProcessService)
        {
            _fileProcessService = fileProcessService;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Process information
        /// </summary>
        /// <param name="participantInformationViewModel"></param>
        /// <returns></returns>
        [HttpPost("Process")]
        public async Task<ActionResult> Process([FromForm] ParticipantInformationViewModel participantInformationViewModel)
        {
            return await _fileProcessService.Process(participantInformationViewModel.Map());
        }

        /// <summary>
        ///Get Process information
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetParticipant")]
        public ActionResult GetParticipant()
        {
            List<ParticipantInformationViewModel> list = new List<ParticipantInformationViewModel>() {
            new ParticipantInformationViewModel(){
              Document = "1234567",
            },
            new ParticipantInformationViewModel(){
              Document = "0123454",
            }

            };
            return Ok(list);
        }
        #endregion
    }
}
