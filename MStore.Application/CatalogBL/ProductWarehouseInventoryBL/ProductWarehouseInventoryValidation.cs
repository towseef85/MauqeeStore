using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.ProductWarehouseInventoryDto;

namespace MStore.Application.CatalogBL.ProductWarehouseInventoryBL
{
    public class ProductWarehouseInventoryValidation : AbstractValidator<PostProductWarehouseInventoryDto>
    {
        public ProductWarehouseInventoryValidation()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty();
            RuleFor(x => x.SubscriptionId).NotNull().NotEmpty();
            RuleFor(x => x.WarehouseId).NotNull().NotEmpty();
        }
    }
}
