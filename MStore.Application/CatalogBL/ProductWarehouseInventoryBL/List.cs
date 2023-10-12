using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductWarehouseInventoryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.ProductWarehouseInventoryBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetProductWarehouseInventoryDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetProductWarehouseInventoryDto>>>
        {
            private readonly IProductWarehouseInventoryRepository _iProductWarehouseInventoryRepo;
            public Handler(IProductWarehouseInventoryRepository iProductWarehouseInventoryRepo)
            {
                _iProductWarehouseInventoryRepo = iProductWarehouseInventoryRepo;
            }
            public async Task<Result<List<GetProductWarehouseInventoryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iProductWarehouseInventoryRepo.GetAllProductWarehouseInventory(request.SubscriptionId);
                return Result<List<GetProductWarehouseInventoryDto>>.Success(result);
            }
        }
    }
}
