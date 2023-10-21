using Microsoft.AspNetCore.Mvc;
using MStore.Application.ShippingBL.WarehouseBL;
using MStore.Application.Dtos.ShippingDto.WarehouseDto;

namespace MStore.AdminAPI.Controllers
{

    public class WarehouseController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostWarehouseDto Warehouse)
        {
            Warehouse.SubscriptionId = GetSubscriptionId();
            Warehouse.Id= Guid.NewGuid();
            return HandleResult(await Mediator.Send(new Create.Command { Warehouse = Warehouse }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostWarehouseDto Warehouse)
        {
            Warehouse.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { Warehouse = Warehouse }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
