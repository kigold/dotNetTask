namespace ProgramsAPI.DTO
{
    public record PersonalInfoRequest(
            bool showPhone = false,
            bool showNationality = false,
            bool showCurrentResidence = false,
            bool showIdNumber = false,
            bool showDateOfBirth = false,
            bool showGender = false
        );
}
