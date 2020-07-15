using System.Reflection;
using System.Runtime.CompilerServices;
using Cms.Domain.Repositories;
using Cms.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Infrastructure.Extensions
{
    public static class RegisterDependencies
    {
        public static IServiceCollection AddCmsContext(this IServiceCollection services, string connectionString)
        {
            return services
                .AddDbContext<CmsContext>(opt =>
                {
                    opt.UseSqlServer(connectionString);
                });
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<INewsRepository, NewsRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}