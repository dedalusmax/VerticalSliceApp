using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VerticalSliceApp.Api.Features.Exams;
using VerticalSliceApp.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(_ =>
    _.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(_ => _.RegisterServicesFromAssembly(assembly));

builder.Services.AddValidatorsFromAssembly(assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

CreateExam.MapEndpoint(app);
//app.MapEndpoint();
// alternative: Carter library

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
