namespace ChallengeTechAndSolve.ViewModels
{
    using ChallengeTechAndSolve.Resources;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Participant information
    /// </summary>
    public class ParticipantInformationViewModel
    {
        /// <summary>
        /// Participant document
        /// </summary>
        [Display(ResourceType = typeof(WebUiResources), Name = nameof(WebUiResources.Document))]
        [MaxLength(15, ErrorMessageResourceType = typeof(WebUiResources), ErrorMessageResourceName = nameof(WebUiResources.Validations_MaxLength))]
        [Required(ErrorMessageResourceType = typeof(WebUiResources), ErrorMessageResourceName = nameof(WebUiResources.Validations_Required))]
        public string Document { get; set; }
        /// <summary>
        /// Information file
        /// </summary>
        [Display(ResourceType = typeof(WebUiResources), Name = nameof(WebUiResources.InformationFile))]
        [Required(ErrorMessageResourceType = typeof(WebUiResources), ErrorMessageResourceName = nameof(WebUiResources.Validations_Required))]
        public IFormFile File { get; set; }
    }
}
