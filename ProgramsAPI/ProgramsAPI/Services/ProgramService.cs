using ProgramsAPI.DTO;
using ProgramsAPI.Repository;

namespace ProgramsAPI.Services
{
    public class ProgramService : IProgramService
    {
        public readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public Task CreateProgram(CreateProgramRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ProgramDataResponse[]> GetProgramData(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task GetProgramData()
        {
            throw new NotImplementedException();
        }

        public Task<ProgramInfoResponse> GetProgramInformation(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProgramInfoResponse[]> GetProgramInformation()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProgram(Guid id, CreateProgramRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
