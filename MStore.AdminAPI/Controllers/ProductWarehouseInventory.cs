using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.ProductWarehouseInventoryBL;
using MStore.Application.Dtos.CatalogDtos.ProductWarehouseInventoryDto;

namespace MStore.AdminAPI.Controllers
{

    public class ProductWarehouseInventoryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostProductWarehouseInventoryDto ProductWarehouseInventory)
        {
            ProductWarehouseInventory.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { ProductWarehouseInventory = ProductWarehouseInventory }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostProductWarehouseInventoryDto ProductWarehouseInventory)
        {
            ProductWarehouseInventory.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { ProductWarehouseInventory = ProductWarehouseInventory }));
        }
    }
}
