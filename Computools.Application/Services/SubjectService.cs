using Computools.Core.Interfaces.Repositories;
using Computools.Core.Interfaces.Services;
using Computools.Core.Models;

namespace Computools.Application.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectService(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task CreateSubject(Subject subject)
    {
        await _subjectRepository.Create(subject);
    }

    public async Task<List<Subject>> FillSubjects()
    {
        return await _subjectRepository.Fill();
    }

    public async Task<List<Subject>> GetSubjectsByStudentId(Guid studentId)
    {
        return await _subjectRepository.GetByStudentId(studentId);
    }
}
