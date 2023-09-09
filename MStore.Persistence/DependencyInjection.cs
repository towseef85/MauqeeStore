using Microsoft.Extensions.DependencyInjection;
using MStore.Application.Interfaces;
using MStore.Persistence.Mappings;
using MStore.Persistence.Repos;

namespace MStore.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IProductAttributeRepository, ProductAttributeRepository>();
            services.AddScoped<ITaxCategoryRepository, TaxCategoryRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IOffersRepository, OffersRepository>();
            services.AddScoped<TokenService>();
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            return services;
        }
    }
}
