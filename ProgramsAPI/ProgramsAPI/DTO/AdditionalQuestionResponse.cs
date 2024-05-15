using ProgramsAPI.Data.Enums;

namespace ProgramsAPI.DTO
{
    public record AdditionalQuestionResponse(
            Guid Id,
            string Question,
            QuestionType QuestionType
        );
}
