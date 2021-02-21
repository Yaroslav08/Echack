using AutoMapper;
using Echack.Application.Interfaces;
using Echack.Application.Services;
using Echack.Domain.Interfaces;
using Echack.Infrastructure.Data;
using Echack.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace Echack.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IChackRepository, ChackRepository>();
            services.AddSingleton<IChackService, ChackService>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<IGroupRepository, GroupRepository>();
            services.AddSingleton<IGroupService, GroupService>();
            services.AddSingleton<IGroupMemberRepository, GroupMemberRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
        }

        public static void AddEchackAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Echack.Application.Mapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}