namespace ProgramsAPI.DTO
{
    public record CreateProgramDataRequest(
            Guid QuestionId,
            string Response,
            string[] MultipleChoice
        );
}
