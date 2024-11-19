using Computools.Core.Interfaces.Repositories;
using Computools.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Computools.Persistance;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ComputoolsDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        
       // services.AddScoped<IUsersRepository, UsersRepository>();
       services.AddScoped<ISubjectRepository, SubjectRepository>();
       services.AddScoped<IStudentRepository, StudentRepository>();
        return services;
    }
}