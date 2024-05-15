using ProgramsAPI.Data.Models;

namespace ProgramsAPI.Repository
{
    public interface IProgramRepository
    {
        Task CreateProgram(ProgramQuestion request);
        Task UpdateProgram(ProgramQuestion request);
        Task CreateProgramResponse(ProgramResponse request);
        Task<ProgramQuestion> GetProgramQuestions(Guid id);
        Task<ProgramQuestion[]> GetProgramQuestions();
        Task<ProgramResponse[]> GetProgramResponse(Guid programId);
        Task<ProgramResponse[]> GetProgramResponse();
    }
}
