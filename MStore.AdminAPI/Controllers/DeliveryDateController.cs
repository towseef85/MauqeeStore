using Microsoft.AspNetCore.Mvc;
using MStore.Application.ShippingBL.DeliveryDateBL;
using MStore.Application.Dtos.ShippingDto.DeliveryDateDto;

namespace MStore.AdminAPI.Controllers
{

    public class DeliveryDateController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostDeliveryDateDto DeliveryDate)
        {
            DeliveryDate.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { DeliveryDate = DeliveryDate }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostDeliveryDateDto DeliveryDate)
        {
            DeliveryDate.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { DeliveryDate = DeliveryDate }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
