using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductAttribute;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CatalogBL.ProductAttributeBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetProductAttributeDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetProductAttributeDto>>>
        {
            private readonly IProductAttributeRepository _iProductAttributeRepo;
            public Handler(IProductAttributeRepository iProductAttributeRepo)
            {
                _iProductAttributeRepo = iProductAttributeRepo;
            }
            public async Task<Result<List<GetProductAttributeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iProductAttributeRepo.GetAllProductAttribute(request.SubscriptionId);
                return Result<List<GetProductAttributeDto>>.Success(result);
            }
        }
    }
}
