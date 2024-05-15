using Microsoft.EntityFrameworkCore;
using ProgramsAPI.Data;
using ProgramsAPI.Data.Models;

namespace ProgramsAPI.Repository
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly ProgramDbContext _context;

        public ProgramRepository(ProgramDbContext context)
        {
            _context = context;
        }

        public async Task CreateProgram(ProgramQuestion request)
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProgram(ProgramQuestion request)
        {
            _context.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task CreateProgramResponse(ProgramResponse request)
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<ProgramResponse[]> GetProgramResponse(Guid programId)
        {
            var programData = await _context.ProgramResponse.Where(x => x.ProgramId == programId).ToListAsync();

            return programData.ToArray();
        }

        public async Task<ProgramResponse[]> GetProgramResponse()
        {
            var programData = await _context.ProgramResponse.ToListAsync();

            return programData.ToArray();
        }

        public async Task<ProgramQuestion> GetProgramQuestions(Guid id)
        {
            var programInfo = await _context.ProgramQuestions.FindAsync(id);

            return programInfo!;
        }

        public async Task<ProgramQuestion[]> GetProgramQuestions()
        {
            var programInfo = await _context.ProgramQuestions.ToListAsync();

            return programInfo.ToArray();
        }
    }
}
