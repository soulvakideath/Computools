using Computools.Application.Services;
using Computools.Core.Interfaces.Services;
using Computools.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Computools.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IStudentService, StudentService>();
        return services;
    }
    
}