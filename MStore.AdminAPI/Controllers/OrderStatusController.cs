using Microsoft.AspNetCore.Mvc;
using MStore.Application.SalesBL.OrderStatusBL;
using MStore.Application.Dtos.SalesDto.OrderStatusDto;

namespace MStore.AdminAPI.Controllers
{

    public class OrderStatusController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostOrderStatusDto OrderStatus)
        {
            OrderStatus.SubscriptionId = GetSubscriptionId();
            OrderStatus.Id= Guid.NewGuid();
            return HandleResult(await Mediator.Send(new Create.Command { OrderStatus = OrderStatus }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostOrderStatusDto OrderStatus)
        {
            OrderStatus.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { OrderStatus = OrderStatus }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
