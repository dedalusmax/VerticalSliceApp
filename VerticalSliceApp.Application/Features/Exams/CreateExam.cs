using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceApp.Application.Common;

namespace VerticalSliceApp.Application.Features.Exams;

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

    //[Authorize]
    public class Controller : ApiControllerBase
    {
        [HttpGet]
        public async Task GetExamsAsync()
        {
            await Task.CompletedTask;
        }
    }

    public class Command : IRequest<Guid>
    {
    }

    public class Validator : AbstractValidator<Command>
    {
    }

    public class Handler : IRequestHandler<Command, Guid>
    {
        Task<Guid> IRequestHandler<Command, Guid>.Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class Event : DomainEvent
    {
    }
}