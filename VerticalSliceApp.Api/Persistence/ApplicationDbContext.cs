using Microsoft.EntityFrameworkCore;
using VerticalSliceApp.Api.Entities;

namespace VerticalSliceApp.Api.Persistence;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Exam> Exams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}