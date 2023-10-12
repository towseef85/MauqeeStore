using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.ProductBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetProductDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetProductDto>>>
        {
            private readonly IProductRepository _iProductRepo;
            public Handler(IProductRepository iProductRepo)
            {
                _iProductRepo = iProductRepo;
            }
            public async Task<Result<List<GetProductDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iProductRepo.GetAllProduct(request.SubscriptionId);
                return Result<List<GetProductDto>>.Success(result);
            }
        }
    }
}
