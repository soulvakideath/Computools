using Computools.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Computools.Persistance.Configuration;

public class SubjectEntityConfiguration : IEntityTypeConfiguration<SubjectEntity>
{
    public void Configure(EntityTypeBuilder<SubjectEntity> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasOne<StudentEntity>()
            .WithMany(s => s.Subjects)
            .HasForeignKey(s => s.StudentId);
    }
}
