using System.Reflection;
using AutoMapper;
using Cms.Domain.Entities;
using Cms.Domain.Mappers;
using Cms.Domain.Repositories;
using Cms.Domain.Requests.Category;
using Cms.Domain.Requests.Category.Validators;
using Cms.Domain.Requests.News;
using Cms.Domain.Requests.News.Validators;
using Cms.Domain.Services.Category;
using Cms.Domain.Services.News;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Domain.Extensions
{
    public static class RegisterDependencies
    {
        public static IServiceCollection BuildDomainDependencies(this IServiceCollection services)
        {
            return services.AddServices()
                .AddValidation()
                .AddMapper();
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<INewsService, NewsService>()
                .AddScoped<ICategoryService, CategoryService>();
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            return services
                .AddTransient<IValidator<AddCategoryRequest>, AddCategoryRequestValidator>()
                .AddTransient<IValidator<EditCategoryRequest>, EditCategoryRequestValidator>()
                .AddTransient<IValidator<AddNewsRequest>, AddNewsRequestValidator>()
                .AddTransient<IValidator<EditNewsRequest>, EditNewsRequestValidator>();
        }

        private static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CmsProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
