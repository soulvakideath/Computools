using System.ComponentModel.DataAnnotations;

namespace Computools.Contracts.Student;

public record CreateStudentRequest(
    [Required] string FirstName,
    [Required] string SecondName,
    [Required] int Age);

public record GetStudentResponse(
    Guid Id,
    string FirstName,
    string SecondName,
    int Age,
    double AverageGrade,
    string Grant);

public record UpdateStudentRequest(
    [Required] string FirstName,
    [Required] string SecondName,
    [Required] int Age);