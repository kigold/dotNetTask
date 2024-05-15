using ProgramsAPI.Data.Models;

namespace ProgramsAPI.Repository
{
    public interface IProgramRepository
    {
        Task CreateProgram(ProgramInformation request);
        Task UpdateProgram(ProgramInformation request);
        Task CreateProgramData(ProgramData request);
        Task<ProgramInformation> GetProgramInformation(Guid id);
        Task<ProgramInformation[]> GetProgramInformation();
        Task<ProgramData[]> GetProgramData(Guid programId);
        Task<ProgramData[]> GetProgramData();
    }
}
