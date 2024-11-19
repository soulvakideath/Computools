using AutoMapper;
using Computools.Core.Enums;
using Computools.Core.Interfaces.Repositories;
using Computools.Core.Models;
using Computools.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace Computools.Persistance.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ComputoolsDbContext _context;
    private readonly IMapper _mapper;

    public StudentRepository(ComputoolsDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Create(Student student)
    {
        var studentEntity = new StudentEntity()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            SecondName = student.SecondName,
            Age = student.Age,
            Grant = student.Grant
        };

        await _context.Students.AddAsync(studentEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Student>> Fill()
    {
        var students = new List<Student>
        {
            Student.Create(Guid.NewGuid(), "John", "Doe", 20, Grant.None),
            Student.Create(Guid.NewGuid(), "Jane", "Smith", 22, Grant.None)
        };

        foreach (var student in students)
        {
            await Create(student);
        }

        return students;
    }

    public async Task SetSubjects(Guid studentId, List<Subject> subjects)
    {
        var studentEntity = await _context.Students
            .Include(s => s.Subjects)
            .FirstOrDefaultAsync(s => s.Id == studentId);

        if (studentEntity == null) throw new Exception("Student not found!");

        studentEntity.Subjects.Clear();
        foreach (var subject in subjects)
        {
            studentEntity.Subjects.Add(new SubjectEntity
            {
                Id = subject.Id,
                Name = subject.Name,
                Grade = subject.Grade,
                Date = subject.Date,
                StudentId = studentId
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task<double> CalculateAverageGrade(Guid studentId)
    {
        var studentEntity = await _context.Students
            .Include(s => s.Subjects)
            .FirstOrDefaultAsync(s => s.Id == studentId);

        if (studentEntity == null) throw new Exception("Student not found!");

        return studentEntity.Subjects.Count == 0 ? 0 : studentEntity.Subjects.Average(s => s.Grade);
    }

    public async Task SetGrant(Guid studentId)
    {
        var studentEntity = await _context.Students
            .FirstOrDefaultAsync(s => s.Id == studentId);

        if (studentEntity == null) throw new Exception("Student not found!");

        var averageGrade = await CalculateAverageGrade(studentId);
        if (averageGrade < 60)
        {
            studentEntity.Grant = Grant.None;
        }
        else if (averageGrade >= 60 && averageGrade < 90)
        {
            studentEntity.Grant = Grant.Regular;
        }
        else
        {
            studentEntity.Grant = Grant.Increased;
        }

        await _context.SaveChangesAsync();
    }
}