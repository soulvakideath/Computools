using System.Text;
using Computools.Endpoints;
using Microsoft.AspNetCore.Authorization;

namespace Computools.Extensions;

public static class ApiExtensions
{
    public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
    {
        //app.Endpoints
        app.MapSubjectsEndpoints();
        app.MapStudentsEndpoints();
    }
    
}