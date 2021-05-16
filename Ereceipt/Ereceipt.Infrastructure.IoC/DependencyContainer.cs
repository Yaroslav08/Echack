using AutoMapper;
using Ereceipt.Application.Services.Implementations;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.Wrappers;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Infrastructure.Data.Repositories.EF;
using Microsoft.Extensions.DependencyInjection;
namespace Ereceipt.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IReceiptRepository, ReceiptRepository>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ITestDataRepository, TestDataRepository>();
            services.AddScoped<ITestDataService, TestDataService>();
            services.AddScoped<IJsonConverter, JsonConverter>();
            services.AddScoped<IAuthenticationService, TokenAuthenticationService>();
            services.AddScoped<IUsernameService, UsernameService>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<IBudgetService, BudgetService>();
            services.AddScoped<IGroupMemberCheck, GroupMemberCheck>();
            services.AddScoped<IBudgetCategoryRepository, EFBudgetCategoryRepository>();
        }

        public static void AddEreceiptAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Ereceipt.Application.Mapper(new JsonConverter()));
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}