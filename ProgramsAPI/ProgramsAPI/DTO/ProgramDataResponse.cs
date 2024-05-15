namespace ProgramsAPI.DTO
{
    public record ProgramDataResponse(
            Guid Id,
            Guid ProgramId,
            Guid QuestionId,
            string Response,
            string[] MultipleResponse
        );
}
