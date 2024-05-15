namespace ProgramsAPI.DTO
{
    public record ProgramAnswerResponse(
            Guid Id,
            Guid ProgramId,
            ProgramAnswer[] Answers
        );

    public record ProgramAnswer(
            Guid QuestionId,
            string Response,
            string[] MultipleResponse
        );
}
