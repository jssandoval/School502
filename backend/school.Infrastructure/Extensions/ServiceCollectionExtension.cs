using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using school.Core.CustomEntities;
using school.Core.Interfaces;
using school.Core.Services;
using school.Infrastructure.Data;
using school.Infrastructure.Interfaces;
using school.Infrastructure.Options;
using school.Infrastructure.Repositories;
using school.Infrastructure.Services;

namespace school.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // MongoDB
            services.Configure<DBSettings>(options =>
            {
                options.ConnectionString = configuration.GetSection("SchoolStoreDatabaseSettings:ConnectionString").Value;
                options.DatabaseName = configuration.GetSection("SchoolStoreDatabaseSettings:DatabaseName").Value;
            });
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //injeccion de dependencias
            //services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            //services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISchoolService, SchoolService>();
            //services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddSingleton<IUriService>(provider => {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
            return services;
        }

        public static IServiceCollection AddJwtAuthentications(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
                };
            });
            return services;
        }

        public static IServiceCollection AddSwaggers(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc => {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Schools API", Version = "v1" });

                //var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                //doc.IncludeXmlComments(xmlPath);

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IServiceCollection AddCordss(this IServiceCollection services)
        {
            return services;
        }
    }
}
