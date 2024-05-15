
namespace ProgramsAPI.DTO
{
    public record CreateProgramRequest(
            string Title,
            string Description,
            AddAdditionalQuestionsRequest[] AdditionalQuestions,
            PersonalInfoRequest personalInfoSetting
        );
}
