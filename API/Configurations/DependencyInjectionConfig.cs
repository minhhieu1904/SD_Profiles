using API._Repositories;
using API._Services.Interfaces;
using API._Services.Services;

namespace API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Add RepositoryAccessor
            services.AddScoped<IRepositoryAccessor, RepositoryAccessor>();

            // Add Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IFaqService, FaqService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<ISubscribeService, SubscribeService>();
            services.AddScoped<IPermissionSettingService, PermissionSettingService>();
        }
    }
}