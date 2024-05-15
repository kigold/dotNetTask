using ProgramsAPI.Data.Enums;

namespace ProgramsAPI.DTO
{
    public record AddAdditionalQuestionsRequest(string Question, QuestionType QuestionType, string[] Choices);
}
