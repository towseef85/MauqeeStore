using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductWarehouseInventoryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.ProductWarehouseInventoryBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostProductWarehouseInventoryDto ProductWarehouseInventory { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductWarehouseInventory).SetValidator(new ProductWarehouseInventoryValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IProductWarehouseInventoryRepository _iProductWarehouseInventoryRepo;
            public Handler(IProductWarehouseInventoryRepository iProductWarehouseInventoryRepo)
            {
                _iProductWarehouseInventoryRepo = iProductWarehouseInventoryRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iProductWarehouseInventoryRepo.AddProductWarehouseInventory(request.ProductWarehouseInventory, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Product Warehouse Inventory");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
