using Computools.Core.Interfaces.Repositories;
using Computools.Core.Interfaces.Services;
using Computools.Core.Models;

namespace Computools.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task CreateStudent(Student student)
    {
        await _studentRepository.Create(student);
    }

    public async Task<List<Student>> FillStudents()
    {
        return await _studentRepository.Fill();
    }

    public async Task SetSubjects(Guid studentId, List<Subject> subjects)
    {
        await _studentRepository.SetSubjects(studentId, subjects);
    }

    public async Task<double> CalculateAverageGrade(Guid studentId)
    {
        return await _studentRepository.CalculateAverageGrade(studentId);
    }

    public async Task SetGrant(Guid studentId)
    {
        await _studentRepository.SetGrant(studentId);
    }
}