namespace Computools.Persistance.Entities;

public class SubjectEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid StudentId { get; set; }
    public int Grade { get; set; }
    public DateTime Date { get; set; }
}
