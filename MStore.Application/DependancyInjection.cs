using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MStore.Application.CatalogBL.CategoryBL;

namespace MStore.Application
{
    public static class DependancyInjection
    {
       
            public static IServiceCollection AddApplication(this IServiceCollection services)
            {
                services.AddMediatR(typeof(Create.Command).Assembly);
                //services.AddMediatR(typeof(List.Query).Assembly);

                return services;
            }
        
    }
}
