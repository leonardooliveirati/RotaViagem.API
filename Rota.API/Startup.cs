using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Rota.Domain.Interface;
using Rota.Domain.Service;
using Rota.Entities.ViewModel;
using Rota.Infrastructure;
using Rota.Infrastructure.Repository;
using System.Configuration;

namespace Rota.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rota viagens API v1");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rota viagens API", Version = "v1" });
            });

            services.AddScoped<IRotaRepository, RotaRepository>();

            services.AddDbContext<RotaDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RotaDbContext")));

            //services.AddScoped<IBaseRepository<Credit>, BaseRepository<Credit>>();
            //services.AddScoped<IRotaRepository, RotaRepository>();
            services.AddScoped<IRotaService, RotaService>();
        }

    }
}
