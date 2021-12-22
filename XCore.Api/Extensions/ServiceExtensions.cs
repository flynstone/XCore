using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCore.Entities;
using XCore.LoggerService;
using XCore.Repositories;
using XCore.Repositories.Interfaces;
using XCore.Repositories.Interfaces.Overtime;
using XCore.Repositories.Overtime;

namespace XCore.Api.Extensions
{
    public static class ServiceExtensions
    {
        // Configure Cross Origin Policies
        public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options => 
            { 
                options.AddPolicy("CorsPolicy", builder =>     
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()); 
            });

        // Configure IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) => 
            services.Configure<IISOptions>(options => { });

        // Configure Logger Service
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }

        // Configure Scopes
        public static void ConfigureExtensions(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IMediaRepository, MediaRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IBackupRepository, BackupRepository>();
            services.AddScoped<ICrewRepository, CrewRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IJobTitleRepository, JobTitleRepository>();
            services.AddScoped<IRuleTypeRepository, RuleTypeRepository>();
        }

        // Configure Swagger
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "X-Core Api",
                    Version = "v1",
                    Description = "COMP200 && COMP266 Api Database by X-Core Web",
                    TermsOfService = new Uri("https://x-coreweb.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Julien Lacroix",
                        Email = "flynstone@x-coreweb.com",
                        Url = new Uri("https://x-coreweb.com")
                    }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                        },
                        new List<string>()
                    }

                });
            });
        }

        // Configure SQL Server
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<XCoreDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), (b => b.MigrationsAssembly("XCore.Api"))));
        }

    }
}
