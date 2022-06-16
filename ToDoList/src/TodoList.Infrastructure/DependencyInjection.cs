using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TodoList.Application.Common.Configurations;
using TodoList.Application.Common.Interfaces;
using TodoList.Infrastructure.Identity;
using TodoList.Infrastructure.Persistence;
using TodoList.Infrastructure.Persistence.Repositories;
using TodoList.Infrastructure.Services;

namespace TodoList.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TodoListDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("SqlServerConnection"),
                b => b.MigrationsAssembly(typeof(TodoListDbContext).Assembly.FullName)));

        services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        
        services
            .AddIdentity<ApplicationUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequiredLength = 6;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<TodoListDbContext>()
            .AddDefaultTokenProviders();

        // 注入认证服务
        services.AddTransient<IIdentityService, IdentityService>();

        // 增加依赖注入
        services.AddScoped<IDomainEventService, DomainEventService>();
        
        var jwtConfiguration = new JwtConfiguration();
        configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

        services.Configure<JwtConfiguration>("JwtSettings", configuration.GetSection("JwtSettings"));
        services.Configure<JwtConfiguration>("JwtApiV2Settings", configuration.GetSection("JwtApiV2Settings"));
        
        services
            .AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtConfiguration.ValidIssuer,
                    ValidAudience = jwtConfiguration.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET") ?? "TodoListApiSecretKey"))
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("OnlyAdmin", policy => policy.RequireRole("Administrator"));
            options.AddPolicy("OnlySuper", policy => policy.RequireRole("SuperAdmin"));
        });
        
        return services;
    } 
}