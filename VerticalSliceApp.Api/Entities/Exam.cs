namespace VerticalSliceApp.Api.Entities;

public class Exam
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public List<DateTime> Dates { get; set; } = [];
}
