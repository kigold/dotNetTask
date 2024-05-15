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
            var program = new ProgramQuestion
            {
                Title = request.Title,
                Description = request.Description,
                AdditionalQuestions = request.AdditionalQuestions.Select(x => new AdditionalQuestion
                {
                    Question = x.Question,
                    QuestionType = x.QuestionType,
                    Choices = x.Choices?.Select(x => new Choice { Response = x }).ToArray() ?? Array.Empty<Choice>() 
                }).ToArray(),
                PersonalInformation = GeneratePersonalInfo(request.PersonalInformation)
            };
            await _programRepository.CreateProgram(program);
        }

        public async Task UpdateProgram(Guid id, CreateProgramRequest request)
        {
            var program = new ProgramQuestion
            {
                Id = id,
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

        public async Task CreateProgramResponse(Guid programId, CreateProgramDataRequest[] request)
        {
            var programResponse = new ProgramResponse
            {
                ProgramId = programId,
                Responses = request.Select(x => new Response
                {
                    QuestionId = x.QuestionId,
                    MultipleChoice = x.MultipleChoice.Select(x => new Choice { Response = x }).ToArray(),
                    Answer = x.Response
                }).ToArray()

            };
            await _programRepository.CreateProgramResponse(programResponse);
        }

        public async Task<ProgramAnswerResponse[]> GetProgramResponse(Guid id)
        {
            var programData = await _programRepository.GetProgramResponse(id);
            return programData.Select(x => ToProgramDataResponse(x)).ToArray();
        }

        public async Task<ProgramAnswerResponse[]> GetProgramResponse()
        {
            var programData = await _programRepository.GetProgramResponse();
            return programData.Select(x => ToProgramDataResponse(x)).ToArray();
        }

        public async Task<ProgramQuestionsResponse> GetProgramQuestions(Guid id)
        {
            var programQuestions = await _programRepository.GetProgramQuestions(id);
            return ToProgramQuestionsResponse(programQuestions);
        }

        public async Task<ProgramQuestionsResponse[]> GetProgramQuestions()
        {
            var programQuestions = await _programRepository.GetProgramQuestions();
            return programQuestions.Select(x => ToProgramQuestionsResponse(x)).ToArray();
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

        private ProgramQuestionsResponse ToProgramQuestionsResponse(ProgramQuestion source)
        {
            return new ProgramQuestionsResponse(
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
                    source.QuestionType,
                    source.Choices.Select(x => x.Response).ToArray()
                );
        }

        private ProgramAnswerResponse ToProgramDataResponse(ProgramResponse source)
        {
            return new ProgramAnswerResponse(
                source.Id,
                source.ProgramId,
                source.Responses.Select(x => new ProgramAnswer(
                        x.QuestionId,
                        x.Answer,
                        x.MultipleChoice.Select(x => x.Response).ToArray()
                    )).ToArray()
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
