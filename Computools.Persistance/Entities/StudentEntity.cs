using Computools.Core.Enums;

namespace Computools.Persistance.Entities;

public class StudentEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public int Age { get; set; }
    public Grant Grant { get; set; }
    public List<SubjectEntity> Subjects { get; set; } = new();
}