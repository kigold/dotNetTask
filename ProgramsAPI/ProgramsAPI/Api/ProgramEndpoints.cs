using Microsoft.AspNetCore.Http.HttpResults;
using ProgramsAPI.DTO;
using ProgramsAPI.Services;

namespace ProgramsAPI.Api
{
    public static class ProgramEndpoints
    {
        private const string PATH_BASE = "program";
        private const string TAGS = "program api";

        public static WebApplication MapProgramEndpoints(this WebApplication app)
        {
            var programGroup = app.MapGroup(PATH_BASE).WithTags(TAGS);

            programGroup.MapPost("/", CreateProgram);
            programGroup.MapPut("/{{id}}", UpdateProgram);
            programGroup.MapPost("/response/{{programId}}", CreateProgramResponse);
            programGroup.MapGet("/", GetProgram);
            programGroup.MapGet("/{{id}}", GetPrograms);
            programGroup.MapGet("/response", GetAllProgramResponse);
            programGroup.MapGet("/response/{{id}}", GetProgramResponse);

            return app;
        }

        //POST /
        public static async Task<Results<NoContent, ValidationProblem>> CreateProgram(IProgramService programService, CreateProgramRequest request)
        {
            await programService.CreateProgram(request);

            return TypedResults.NoContent();
        }

        //PUT /
        public static async Task<Results<NoContent, ValidationProblem>> UpdateProgram(IProgramService programService, Guid id, CreateProgramRequest request)
        {
            await programService.UpdateProgram(id, request);

            return TypedResults.NoContent();
        }

        //POST /response/{{programId}}
        public static async Task<Results<NoContent, ValidationProblem>> CreateProgramResponse(IProgramService programService, Guid programId, CreateProgramDataRequest[] request)
        {
            await programService.CreateProgramResponse(programId, request);

            return TypedResults.NoContent();
        }

        //GET /
        public static async Task<Results<Ok<ProgramQuestionsResponse[]>, ValidationProblem>> GetProgram(IProgramService programService)
        {
            var result = await programService.GetProgramQuestions();

            return TypedResults.Ok(result);
        }

        //GET /{{id}}
        public static async Task<Results<Ok<ProgramQuestionsResponse>, ValidationProblem>> GetPrograms(IProgramService programService, Guid id)
        {
            var result = await programService.GetProgramQuestions(id);

            return TypedResults.Ok(result);
        }

        //GET /response
        public static async Task<Results<Ok<ProgramAnswerResponse[]>, ValidationProblem>> GetAllProgramResponse(IProgramService programService)
        {
            var result = await programService.GetProgramResponse();

            return TypedResults.Ok(result);
        }

        //GET /response/{{id}}
        public static async Task<Results<Ok<ProgramAnswerResponse[]>, ValidationProblem>> GetProgramResponse(IProgramService programService, Guid id)
        {
            var result = await programService.GetProgramResponse(id);

            return TypedResults.Ok(result);
        }
    }
}
