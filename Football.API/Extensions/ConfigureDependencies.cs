using Football.API.Common.Contracts;
using Football.API.Common.Implementations;
using Football.API.DataAccess.Contracts;
using Football.API.DataAccess.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Football.API.Extensions
{
    public static class ConfigureDependencies
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var properties = configuration.GetSection(nameof(Properties)).Get<Properties>();
            services.AddSwaggerGen(options =>
            {
                var groupName = properties.Version;
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"{properties.Title} {groupName}",
                    Version = groupName,
                    Description = properties.Description,
                    Contact = new OpenApiContact
                    {
                        Name = properties.Contact.Name,
                        Email = properties.Contact.Email,
                        Url = new Uri(properties.Contact.Url),
                    }
                });
            });
        }
    }
}
