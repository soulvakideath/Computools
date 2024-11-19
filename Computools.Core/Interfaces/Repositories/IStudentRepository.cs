using Computools.Core.Models;

namespace Computools.Core.Interfaces.Repositories;

public interface IStudentRepository
{
    Task Create(Student student);
    Task<List<Student>> Fill();
    Task SetSubjects(Guid studentId, List<Subject> subjects);
    Task<double> CalculateAverageGrade(Guid studentId);
    Task SetGrant(Guid studentId);
}
