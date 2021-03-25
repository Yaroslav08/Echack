using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.Services;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Ereceipt.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IReceiptRepository, ReceiptRepository>();
            services.AddSingleton<IReceiptService, ReceiptService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<IGroupRepository, GroupRepository>();
            services.AddSingleton<IGroupService, GroupService>();
            services.AddSingleton<IGroupMemberRepository, GroupMemberRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<ITestDataService, TestDataService>();
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