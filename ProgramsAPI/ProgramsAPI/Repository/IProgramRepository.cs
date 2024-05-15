using ProgramsAPI.Data.Models;

namespace ProgramsAPI.Repository
{
    public interface IProgramRepository
    {
        Task CreateProgram(ProgramInformation request);
        Task UpdatePersonalQuestions(ProgramInformation request);
    }
}
