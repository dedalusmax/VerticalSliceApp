using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceApp.Api.Common;
using VerticalSliceApp.Api.Entities;
using VerticalSliceApp.Api.Persistence;

namespace VerticalSliceApp.Api.Features.Exams;

//[Authorize]
public class ExamController : ApiControllerBase
{
    [HttpGet]
    public async Task GetExamsAsync()
    {
        await Task.CompletedTask;
    }
}

public class CreateExamCommand : IRequest<Guid>
{
}

public class CreateExamCommandValidator : AbstractValidator<CreateExamCommand>
{
}

public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, Guid>
{
    Task<Guid> IRequestHandler<CreateExamCommand, Guid>.Handle(CreateExamCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class ExamCreatedEvent : DomainEvent
{
}

public static class CreateExam
{
    public static void MapEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("api/exams", async (Command command, ISender sender) => 
        {
            var examId = await sender.Send(command);
            return Results.Ok(examId);
        });
    }

    public class Command : IRequest<Guid>
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.Description).MaximumLength(250);
        }
    }

    internal sealed class Handler(ApplicationDbContext dbContext, IValidator<Command> validator) : IRequestHandler<Command, Guid>
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IValidator<Command> _validator = validator;

        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var exam = new Exam
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description
            };

            _dbContext.Add(exam);
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            return exam.Id;
        }
    }

    public class Event : DomainEvent
    {
    }
}