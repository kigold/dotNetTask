using Microsoft.EntityFrameworkCore;
using ProgramsAPI;
using ProgramsAPI.Api;
using ProgramsAPI.Data;
using ProgramsAPI.Repository;
using ProgramsAPI.Services;
using ProgramsAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();

var dbSetting = builder.Configuration.GetSection(nameof(DbConfig)).Get<DbConfig>();
builder.Services.AddDbContext<ProgramDbContext>(options => options.UseCosmos(dbSetting!.ConnectionString, dbSetting.DatabaseName));

builder.Services.AddHostedService<DbSetupWorker>();

var app = builder.Build();

app.MapProgramEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

