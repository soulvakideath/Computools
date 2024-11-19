using Computools.Application.Services;
using Computools.Contracts.Subjects;
using Computools.Core.Interfaces.Services;
using Computools.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Computools.Endpoints;

public static class SubjectsEndpoints
{
    public static IEndpointRouteBuilder MapSubjectsEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("subjects");

        endpoints.MapPost(string.Empty, CreateSubject);
        endpoints.MapGet(string.Empty, GetSubjects);
        endpoints.MapGet("student/{studentId:guid}", GetSubjectsByStudentId);

        return endpoints;
    }

    private static async Task<IResult> CreateSubject(
        [FromBody] CreateSubjectRequest request,
        ISubjectService subjectService)
    {
        var subject = new Subject(
            Guid.NewGuid(),
            request.Name,
            request.StudentId,
            request.Grade,
            request.Date);

        await subjectService.CreateSubject(subject);

        return Results.Created($"/subjects/{subject.Id}", subject);
    }

    private static async Task<IResult> GetSubjects(
        ISubjectService subjectService)
    {
        var subjects = await subjectService.FillSubjects();

        var response = subjects.Select(s => new GetSubjectResponse(
            s.Id,
            s.Name,
            s.StudentId,
            s.Grade,
            s.Date));

        return Results.Ok(response);
    }

    private static async Task<IResult> GetSubjectsByStudentId(
        [FromRoute] Guid studentId,
        ISubjectService subjectService)
    {
        var subjects = await subjectService.GetSubjectsByStudentId(studentId);

        var response = subjects.Select(s => new GetSubjectResponse(
            s.Id,
            s.Name,
            s.StudentId,
            s.Grade,
            s.Date));

        return Results.Ok(response);
    }
}