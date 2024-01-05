using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Startups.Domain.Repositories;
using Startups.Domain.Services;
using Startups.Infrastructure.Data;
using Startups.Infrastructure.Repositories;
using Startups.Infrastructure.Services;

namespace Startups.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IStartupRepository, StartupRepository>();
            services.AddScoped<IFounderRepository, FounderRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
