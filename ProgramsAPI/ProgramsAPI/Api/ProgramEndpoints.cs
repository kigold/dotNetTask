using Microsoft.AspNetCore.Http.HttpResults;
using ProgramsAPI.DTO;
using ProgramsAPI.Services;

namespace ProgramsAPI.Api
{
    public static class ProgramEndpoints
    {
        private const string PATH_BASE = "program";
        private const string TAGS = "progam api";

        public static WebApplication MapProgramEndpoints(this WebApplication app)
        {
            var programGroup = app.MapGroup(PATH_BASE).WithTags(TAGS);

            programGroup.MapPost("/", CreateProgram);
            programGroup.MapPut("/{{id}}", UpdateProgram);
            programGroup.MapPost("/data/{{programId}}", CreateProgramData);
            programGroup.MapGet("/", GetProgram);
            programGroup.MapGet("/{{id}}", GetPrograms);
            programGroup.MapGet("/data", GetAllProgramData);
            programGroup.MapGet("/data/{{id}}", GetProgramData);

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

        //POST /data/{{programId}}
        public static async Task<Results<NoContent, ValidationProblem>> CreateProgramData(IProgramService programService, Guid programId, CreateProgramDataRequest request)
        {
            await programService.CreateProgramData(programId, request);

            return TypedResults.NoContent();
        }

        //GET /
        public static async Task<Results<Ok<ProgramInfoResponse[]>, ValidationProblem>> GetProgram(IProgramService programService)
        {
            var result = await programService.GetProgramInformation();

            return TypedResults.Ok(result);
        }

        //GET /{{id}}
        public static async Task<Results<Ok<ProgramInfoResponse>, ValidationProblem>> GetPrograms(IProgramService programService, Guid id)
        {
            var result = await programService.GetProgramInformation(id);

            return TypedResults.Ok(result);
        }

        //GET /data
        public static async Task<Results<Ok<ProgramDataResponse[]>, ValidationProblem>> GetAllProgramData(IProgramService programService)
        {
            var result = await programService.GetProgramData();

            return TypedResults.Ok(result);
        }

        //GET /data/{{id}}
        public static async Task<Results<Ok<ProgramDataResponse[]>, ValidationProblem>> GetProgramData(IProgramService programService, Guid id)
        {
            var result = await programService.GetProgramData(id);

            return TypedResults.Ok(result);
        }
    }
}
