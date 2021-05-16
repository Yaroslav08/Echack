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
            services.AddScoped<IReceiptRepository, EFReceiptRepository>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICommentRepository, EFCommentRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IGroupRepository, EFGroupRepository>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupMemberRepository, EFGroupMemberRepository>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrencyRepository, EFCurrencyRepository>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ITestDataRepository, EFTestDataRepository>();
            services.AddScoped<ITestDataService, TestDataService>();
            services.AddScoped<IJsonConverter, JsonConverter>();
            services.AddScoped<IAuthenticationService, TokenAuthenticationService>();
            services.AddScoped<IUsernameService, UsernameService>();
            services.AddScoped<IBudgetRepository, EFBudgetRepository>();
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