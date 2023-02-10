using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Football.API.DataAccess;
using Football.API.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

namespace Football.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FootballContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection") ?? string.Empty));
            services.Configure<Properties>(options => Configuration.GetSection("Properties").Bind(options));
            services.ConfigureRepositoryWrapper();
            services.ConfigureLoggerService();
            services.AddAutoMapper(typeof(Program));
            services.AddControllers();
            services.AddMvc();
            services.ConfigureSwagger(Configuration);
            services.ConfigureServices();
            services.ConfigureCors();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

    }
}
