using Computools.Application.Services;
using Computools.Contracts.Student;
using Computools.Core.Enums;
using Computools.Core.Interfaces.Services;
using Computools.Core.Models;
using Microsoft.AspNetCore.Mvc;

public static class StudentsEndpoints
    {
        public static IEndpointRouteBuilder MapStudentsEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("students");

            endpoints.MapPost(string.Empty, CreateStudent);
            endpoints.MapGet(string.Empty, GetStudents);
            endpoints.MapPost("{id:guid}/subjects", SetSubjects);
            endpoints.MapGet("{id:guid}/average-grade", CalculateAverageGrade);
            endpoints.MapPost("{id:guid}/grant", SetGrant);

            return endpoints;
        }

        private static async Task<IResult> CreateStudent(
            [FromBody] CreateStudentRequest request,
            IStudentService studentService)
        {
            var student = new Student(
                Guid.NewGuid(),
                request.FirstName,
                request.SecondName,
                request.Age,
                Grant.None);

            await studentService.CreateStudent(student);

            return Results.Created($"/students/{student.Id}", student);
        }

        private static async Task<IResult> GetStudents(
            IStudentService studentService)
        {
            var students = await studentService.FillStudents();

            var response = students.Select(s => new GetStudentResponse(
                s.Id,
                s.FirstName,
                s.SecondName,
                s.Age,
                s.AverageGrade,
                s.Grant.ToString()));

            return Results.Ok(response);
        }

        private static async Task<IResult> SetSubjects(
            [FromRoute] Guid id,
            [FromBody] List<Subject> subjects,
            IStudentService studentService)
        {
            await studentService.SetSubjects(id, subjects);
            return Results.Ok();
        }

        private static async Task<IResult> CalculateAverageGrade(
            [FromRoute] Guid id,
            IStudentService studentService)
        {
            var averageGrade = await studentService.CalculateAverageGrade(id);
            return Results.Ok(new { AverageGrade = averageGrade });
        }

        private static async Task<IResult> SetGrant(
            [FromRoute] Guid id,
            IStudentService studentService)
        {
            await studentService.SetGrant(id);
            return Results.Ok();
        }
    }