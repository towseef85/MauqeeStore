using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MStore.Application.CatalogBL.CategoryBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application
{
    public static class DependancyInjection
    {
       
            public static IServiceCollection AddApplication(this IServiceCollection services)
            {
                services.AddMediatR(typeof(Create.Command).Assembly);

                return services;
            }
        
    }
}
