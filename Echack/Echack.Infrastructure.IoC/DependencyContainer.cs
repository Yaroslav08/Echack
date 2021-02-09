using Echack.Domain.Interfaces;
using Echack.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace Echack.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChackRepository, ChackRepository>();
        }
    }
}