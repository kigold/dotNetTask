using ProgramsAPI.DTO;

namespace ProgramsAPI.Services
{
    public interface IProgramService
    {
        Task CreateProgram(CreateProgramRequest request);
        Task UpdateProgram(Guid id, CreateProgramRequest request);
        Task<ProgramInfoResponse> GetProgramInformation(Guid id);
        Task<ProgramInfoResponse[]> GetProgramInformation();
        Task<ProgramDataResponse[]> GetProgramData(Guid id);
        Task GetProgramData();
    }
}
