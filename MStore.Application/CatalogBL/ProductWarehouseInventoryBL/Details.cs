using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductWarehouseInventoryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.ProductWarehouseInventoryBL
{
    public class Details
    {
        public class Query : IRequest<Result<GetProductWarehouseInventoryDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetProductWarehouseInventoryDto>>
        {
            private readonly IProductWarehouseInventoryRepository _iProductWarehouseInventoryRepo;
            public Handler(IProductWarehouseInventoryRepository iProductWarehouseInventoryRepo)
            {
                _iProductWarehouseInventoryRepo = iProductWarehouseInventoryRepo;
            }

            public async Task<Result<GetProductWarehouseInventoryDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iProductWarehouseInventoryRepo.GetProductWarehouseInventoryById(request.Id);
                return Result<GetProductWarehouseInventoryDto>.Success(result);

            }
        }
    }
}
