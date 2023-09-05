using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models;
using TechnoAcademyApi.Models.Configuration;
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
            // Mengambil konfigurasi JWT dari appsettings.json
            var jwtSettings = _configuration.GetSection("AppSettings:JwtSettings").Get<JwtSettings>();

            // Menambahkan konfigurasi JWT ke services
            services.Configure<JwtSettings>(_configuration.GetSection("AppSettings:JwtSettings"));

            // Mengonfigurasi autentikasi JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";

                            // Message to be displayed in the "Unauthorized" response
                            var message = "You are not authorized to access this resource.";
                            var result = JsonSerializer.Serialize(new { error = message });
                            return context.Response.WriteAsync(result);
                        }
                    };
                });

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
            services.AddScoped<IGCMEntityService, GCMEntityService>();
            services.AddScoped<IMentorService, MentorService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<ITestimonyService, TestimonyService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddControllers();

            // Konfigurasi Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechnoAcademyApi", Version = "v1" });

                // Konfigurasi autentikasi Bearer
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Input Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
