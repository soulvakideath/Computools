using Computools.Core.Models;

namespace Computools.Core.Interfaces.Services;

public interface ISubjectService
{
    Task CreateSubject(Subject subject);
    Task<List<Subject>> FillSubjects();
    Task<List<Subject>> GetSubjectsByStudentId(Guid studentId);
}