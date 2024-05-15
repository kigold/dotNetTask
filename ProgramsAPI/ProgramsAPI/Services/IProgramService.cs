using ProgramsAPI.DTO;

namespace ProgramsAPI.Services
{
    public interface IProgramService
    {
        Task CreateProgram(CreateProgramRequest request);
        Task UpdateProgram(Guid id, CreateProgramRequest request);
        Task CreateProgramResponse(Guid programId, CreateProgramDataRequest[] request);
        Task<ProgramQuestionsResponse> GetProgramQuestions(Guid id);
        Task<ProgramQuestionsResponse[]> GetProgramQuestions();
        Task<ProgramAnswerResponse[]> GetProgramResponse(Guid id);
        Task<ProgramAnswerResponse[]> GetProgramResponse();
    }
}
