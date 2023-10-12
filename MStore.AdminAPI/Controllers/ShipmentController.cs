using Microsoft.AspNetCore.Mvc;
using MStore.Application.ShippingBL.ShipmentBL;
using MStore.Application.Dtos.ShippingDto.ShipmentDto;

namespace MStore.AdminAPI.Controllers
{

    public class ShipmentController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostShipmentDto Shipment)
        {
            Shipment.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { Shipment = Shipment }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostShipmentDto Shipment)
        {
            Shipment.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { Shipment = Shipment }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
