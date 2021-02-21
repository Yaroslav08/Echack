using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Services;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Infrastructure.Data;
using Ereceipt.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace Ereceipt.Infrastructure.IoC
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

        public static void AddEreceiptAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Ereceipt.Application.Mapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}