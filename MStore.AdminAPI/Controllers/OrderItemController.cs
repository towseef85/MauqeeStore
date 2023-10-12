using Microsoft.AspNetCore.Mvc;
using MStore.Application.SalesBL.OrderItemBL;
using MStore.Application.Dtos.SalesDto.OrderItemDto;

namespace MStore.AdminAPI.Controllers
{

    public class OrderItemController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostOrderItemDto OrderItem)
        {
            OrderItem.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { OrderItem = OrderItem }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostOrderItemDto OrderItem)
        {
            OrderItem.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { OrderItem = OrderItem }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
