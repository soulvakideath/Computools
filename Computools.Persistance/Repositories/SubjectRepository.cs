using AutoMapper;
using Computools.Core.Interfaces.Repositories;
using Computools.Core.Models;
using Computools.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace Computools.Persistance.Repositories;

public class SubjectRepository : ISubjectRepository
{
    private readonly ComputoolsDbContext _context;
    private readonly IMapper _mapper;

    public SubjectRepository(ComputoolsDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Create(Subject subject)
    {
        var subjectEntity = new SubjectEntity()
        {
            Id = subject.Id,
            Name = subject.Name,
            StudentId = subject.StudentId,
            Grade = subject.Grade,
            Date = subject.Date
        };

        await _context.Subjects.AddAsync(subjectEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Subject>> Fill()
    {
        var subjects = new List<Subject>
        {
            Subject.Create(Guid.NewGuid(), "Mathematics", Guid.NewGuid(), 85, DateTime.Now),
            Subject.Create(Guid.NewGuid(), "Physics", Guid.NewGuid(), 90, DateTime.Now),
            Subject.Create(Guid.NewGuid(), "Chemistry", Guid.NewGuid(), 78, DateTime.Now),
            Subject.Create(Guid.NewGuid(), "Biology", Guid.NewGuid(), 92, DateTime.Now),
            Subject.Create(Guid.NewGuid(), "History", Guid.NewGuid(), 65, DateTime.Now)
        };

        foreach (var subject in subjects)
        {
            await Create(subject);
        }

        return subjects;
    }

    public async Task<List<Subject>> GetByStudentId(Guid studentId)
    {
        var subjectEntities = await _context.Subjects
            .AsNoTracking()
            .Where(s => s.StudentId == studentId)
            .ToListAsync();

        return _mapper.Map<List<Subject>>(subjectEntities);
    }
}
