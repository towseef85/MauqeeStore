using Microsoft.AspNetCore.Mvc;
using MStore.Application.SalesBL.OrderBL;
using MStore.Application.Dtos.SalesDto.OrderDto;

namespace MStore.AdminAPI.Controllers
{

    public class OrderController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostOrderDto Order)
        {
            Order.SubscriptionId = GetSubscriptionId();
            Order.Id= Guid.NewGuid();
            return HandleResult(await Mediator.Send(new Create.Command { Order = Order }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostOrderDto Order)
        {
            Order.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { Order = Order }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
