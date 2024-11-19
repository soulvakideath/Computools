using Computools.Core.Enums;
using Computools.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Computools.Persistance.Configuration;

public class StudentEntityConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.FirstName).IsRequired();
        builder.Property(s => s.SecondName).IsRequired();
        builder.Property(s => s.Age).IsRequired();
        builder.Property(s => s.Grant).IsRequired();
    }
}
