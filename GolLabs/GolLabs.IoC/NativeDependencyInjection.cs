using GolLabs.Application.Commands;
using GolLabs.Application.Queries;
using GolLabs.Application.Security;
using GolLabs.Domain.Contracts;
using GolLabs.Domain.Entities;
using GolLabs.Infra.Contexts;
using GolLabs.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GolLabs.IoC
{
    public static class NativeDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddServices();
            services.AddDataServices();
            services.PopulateDataBase();

            return services;
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<UserCommand>();
            services.AddScoped<TripCommand>();
            services.AddScoped<TripQuery>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<GLContext>(opt => opt.UseInMemoryDatabase("GolLabs"));
        }

        public static void PopulateDataBase(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetService<GLContext>();
            context.Users.Add(new User("admin",Security.Encrypt("admin123")));
            context.SaveChanges();
        }
    }
}
