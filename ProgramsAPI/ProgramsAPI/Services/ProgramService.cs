using ProgramsAPI.Data.Models;
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

        public async Task CreateProgram(CreateProgramRequest request)
        {
            var program = new ProgramInformation
            {
                Title = request.Title,
                Description = request.Description,
                AdditionalQuestions = request.AdditionalQuestions.Select(x => new AdditionalQuestion
                {
                    Question = x.Question,
                    QuestionType = x.QuestionType,
                }).ToArray(),
                PersonalInformation = GeneratePersonalInfo(request.PersonalInformation)
            };
            await _programRepository.CreateProgram(program);
        }

        public async Task UpdateProgram(Guid id, CreateProgramRequest request)
        {
            var program = new ProgramInformation
            {
                Title = request.Title,
                Description = request.Description,
                AdditionalQuestions = request.AdditionalQuestions.Select(x => new AdditionalQuestion
                {
                    Question = x.Question,
                    QuestionType = x.QuestionType,
                }).ToArray(),
                PersonalInformation = GeneratePersonalInfo(request.PersonalInformation)
            };
            await _programRepository.UpdateProgram(program);
        }

        public async Task CreateProgramData(Guid programId, CreateProgramDataRequest request)
        {
            var program = new ProgramData
            {
                ProgramId = programId,
                QuestionId = request.QuestionId,
                MultipleChoice = request.MultipleChoice.Select(x => new Choice { Response = x}).ToArray(),
                Response = request.Response
            };
            await _programRepository.CreateProgramData(program);
        }

        public async Task<ProgramDataResponse[]> GetProgramData(Guid id)
        {
            var programData = await _programRepository.GetProgramData(id);
            return programData.Select(x => ToProgramDataResponse(x)).ToArray();
        }

        public async Task<ProgramDataResponse[]> GetProgramData()
        {
            var programData = await _programRepository.GetProgramData();
            return programData.Select(x => ToProgramDataResponse(x)).ToArray();
        }

        public async Task<ProgramInfoResponse> GetProgramInformation(Guid id)
        {
            var programInfo = await _programRepository.GetProgramInformation(id);
            return ToProgramInfoResponse(programInfo);
        }

        public async Task<ProgramInfoResponse[]> GetProgramInformation()
        {
            var programInfo = await _programRepository.GetProgramInformation();
            return programInfo.Select(x => ToProgramInfoResponse(x)).ToArray();
        }

        private PersonalInfoResponse ToPersonalInfoResponse (PersonalInformation source)
        {
            return new PersonalInfoResponse(
                    source.Id,
                    source.Question,
                    source.IsMandatory,
                    source.IsInternal,
                    source.Hide
                );
        }

        private ProgramInfoResponse ToProgramInfoResponse(ProgramInformation source)
        {
            return new ProgramInfoResponse(
                    source.Id,
                    source.Title,
                    source.Description,
                    source.PersonalInformation.Select(x => ToPersonalInfoResponse(x)).ToArray(),
                    source.AdditionalQuestions.Select(x => ToAdditionalQuestions(x)).ToArray()
                    
                    
                );
        }

        private AdditionalQuestionResponse ToAdditionalQuestions(AdditionalQuestion source)
        {
            return new AdditionalQuestionResponse(
                    source.Id,
                    source.Question,
                    source.QuestionType
                );
        }

        private ProgramDataResponse ToProgramDataResponse(ProgramData source)
        {
            return new ProgramDataResponse(
                source.Id,
                source.ProgramId,
                source.QuestionId,
                source.Response,
                source.MultipleChoice.Select(x => x.Response).ToArray()
                );
        }

        private PersonalInformation[] GeneratePersonalInfo(PersonalInfoRequest request)
        {
            return new PersonalInformation[] 
            {
                new PersonalInformation { Question = "First Name", IsMandatory = true, Hide = false, IsInternal = false },
                new PersonalInformation { Question = "Last Name", IsMandatory = true, Hide = false, IsInternal = false },
                new PersonalInformation { Question = "Email", IsMandatory = true, Hide = false, IsInternal = false },
                new PersonalInformation { Question = "Phone", IsMandatory = true, Hide = request.showPhone, IsInternal = false },
                new PersonalInformation { Question = "Nationality", IsMandatory = true, Hide = request.showNationality, IsInternal = false },
                new PersonalInformation { Question = "Current Residence", IsMandatory = true, Hide = request.showCurrentResidence, IsInternal = false },
                new PersonalInformation { Question = "ID Number", IsMandatory = true, Hide = request.showIdNumber, IsInternal = false },
                new PersonalInformation { Question = "Date of Birth", IsMandatory = true, Hide = request.showDateOfBirth, IsInternal = false },
                new PersonalInformation { Question = "Gender", IsMandatory = true, Hide = request.showGender, IsInternal = false },
            };
        }
    }
}
