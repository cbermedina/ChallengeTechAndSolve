namespace ChallengeTechAndSolve.Mappers
{
    using ChallengeTechAndSolve.Business.Models;
    using ChallengeTechAndSolve.ViewModels;

    public static class ParticipantInformationMapper
    {
        public static ParticipantInformationDto Map(this ParticipantInformationViewModel dto)
        {
            return new ParticipantInformationDto()
            {
                Document = dto.Document,
                FileInfo = dto.File,
            };
        }

        public static ParticipantInformationViewModel Map(this ParticipantInformationDto entity)
        {
            return new ParticipantInformationViewModel()
            {
                Document = entity.Document,
                File = entity.FileInfo,
            };
        }
    }
}
