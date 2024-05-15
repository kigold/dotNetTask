
namespace ProgramsAPI.DTO
{
    public record ProgramQuestionsResponse(
            Guid Id,
            string Title,
            string Description,
            PersonalInfoResponse[] PersonalInformation,
            AdditionalQuestionResponse[] AdditionalQuestionResponse
        );
}
