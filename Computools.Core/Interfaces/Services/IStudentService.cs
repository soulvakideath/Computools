using Computools.Core.Models;

namespace Computools.Core.Interfaces.Services;

public interface IStudentService
{
    Task CreateStudent(Student student);
    Task<List<Student>> FillStudents();
    Task SetSubjects(Guid studentId, List<Subject> subjects);
    Task<double> CalculateAverageGrade(Guid studentId);
    Task SetGrant(Guid studentId);
}