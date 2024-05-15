
namespace ProgramsAPI.DTO
{
    public record ProgramInfoResponse(
            Guid Id,
            string Title,
            string Description,
            PersonalInfoResponse[] PersonalInformation,
            AdditionalQuestionResponse[] AdditionalQuestionResponse
        );
}
