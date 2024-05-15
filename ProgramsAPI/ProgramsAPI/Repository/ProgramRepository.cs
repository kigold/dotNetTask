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

        public async Task CreateProgram(ProgramInformation request)
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersonalQuestions(ProgramInformation request)
        {
            var program = await _context.ProgramInformation.FindAsync(request.Id);
            _context.Update(program!);
            await _context.SaveChangesAsync();
            //program.Title = request.Title;
            //program.Description = request.Description;
            //foreach(var info in program.PersonalInformation)
            //{
            //    var update = request.PersonalInformation.FirstOrDefault(x => x.Id == info.Id);
            //    if (update != null)
            //    {
            //        info.Question = update.Question;
            //        info.IsMandatory = update.IsMandatory;
            //        info.IsInternal = update.IsInternal;
            //        info.Hide = update.Hide;
            //    }
            //}

            //foreach (var question in program.AdditionalQuestions)
            //{
            //    var update = request.AdditionalQuestions.FirstOrDefault(x => x.Id == question.Id);
            //    if (update != null)
            //    {
            //        question.Question = update.Question;
            //        question.QuestionType = update.QuestionType;
            //    }
            //}
        }

        public async Task<ProgramData[]> GetProgramData(Guid programId)
        {
            var programData = await _context.ProgramData.Where(x => x.ProgramId == programId).ToListAsync();

            return programData.ToArray();
        }

        public async Task<ProgramData[]> GetProgramData()
        {
            var programData = await _context.ProgramData.ToListAsync();

            return programData.ToArray();
        }

        public async Task<ProgramInformation> GetProgramInformation(Guid id)
        {
            var programInfo = await _context.ProgramInformation.FindAsync(id);

            return programInfo!;
        }

        public async Task<ProgramInformation[]> GetProgramInformation()
        {
            var programInfo = await _context.ProgramInformation.ToListAsync();

            return programInfo.ToArray();
        }
    }
}
