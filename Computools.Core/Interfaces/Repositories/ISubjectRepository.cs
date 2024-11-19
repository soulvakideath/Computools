using Computools.Core.Models;

namespace Computools.Core.Interfaces.Repositories;

public interface ISubjectRepository
{
    Task Create(Subject subject);
    Task<List<Subject>> Fill();
    Task<List<Subject>> GetByStudentId(Guid studentId);
}


