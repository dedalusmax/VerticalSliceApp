using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceApp.Api.Persistence;

namespace VerticalSliceApp.Api.Features.Exams;

public static class GetExams
{
    public static void MapEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("api/exams", async (ISender sender) =>
        {
            var result = await sender.Send(new Query());
            return Results.Ok(result);
        });

        // alternative: Mapster library
    }

    public record Response
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public List<DateTime> Dates { get; set; } = [];
    }

    public class Query : IRequest<IList<Response>>
    {

    }

    internal sealed class Handler(ApplicationDbContext dbContext) : IRequestHandler<Query, IList<Response>>
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IList<Response>> Handle(Query request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Exams
                .Select(_ => new Response
                {
                    Id = _.Id,
                    Name = _.Name,
                    Description = _.Description,
                    Dates = _.Dates
                })
                .ToListAsync(cancellationToken);

            return response;
        }
    }
}
