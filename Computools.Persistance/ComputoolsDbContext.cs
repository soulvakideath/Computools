using Computools.Core.Models;
using Computools.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace Computools.Persistance;

public class ComputoolsDbContext(DbContextOptions<ComputoolsDbContext> options)
    : DbContext(options)
{
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComputoolsDbContext).Assembly);
    }
}