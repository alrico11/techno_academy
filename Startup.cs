using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models;
using TechnoAcademyApi.Services;
using TechnoAcademyApi.Services.Impl;

namespace TechnoAcademyApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Konfigurasi koneksi database MySQL
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Registrasi service dan interface
            services.AddScoped<IFormRegisterService, FormRegisterService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IProgramCategoryService, ProgramCategoryService>();
            services.AddScoped<IProgramEntityService, ProgramEntityService>();
            services.AddScoped<IAppliedProgramService, AppliedProgramService>();
            services.AddScoped<IStatusLogService, StatusLogService>();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechnoAcademyApi v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
