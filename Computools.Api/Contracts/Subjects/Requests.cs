using System.ComponentModel.DataAnnotations;

namespace Computools.Contracts.Subjects;

public record CreateSubjectRequest(
    [Required] string Name,
    [Required] Guid StudentId,
    [Required] int Grade,
    [Required] DateTime Date);

public record GetSubjectResponse(
    Guid Id,
    string Name,
    Guid StudentId,
    int Grade,
    DateTime Date);

public record UpdateSubjectRequest(
    [Required] string Name,
    [Required] int Grade,
    [Required] DateTime Date);