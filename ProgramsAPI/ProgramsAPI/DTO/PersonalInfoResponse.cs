namespace ProgramsAPI.DTO
{
    public record PersonalInfoResponse(
            Guid Id,
            string Question,
            bool IsMandatory,
            bool IsInternal,
            bool Hide
        );
}
