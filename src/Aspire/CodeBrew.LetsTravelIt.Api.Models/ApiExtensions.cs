using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBrew.LetsTravelIt.Api.Models
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddLetsTravelItApi(this IServiceCollection services)
        {
            services.AddFastEndpoints();
            return services;
        }

        public static IApplicationBuilder UseLetsTravelItApi(this IApplicationBuilder app)
        {
            app.UseFastEndpoints();
            return app;
        }
    }
}
