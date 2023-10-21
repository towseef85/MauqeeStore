using Microsoft.AspNetCore.Mvc;
using MStore.Application.FinanceBL.StoreBL;
using MStore.Application.Dtos.FinanceDto.StoreDto;

namespace MStore.AdminAPI.Controllers
{

    public class StoreController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostStoreDto Store)
        {
            Store.SubscriptionId = GetSubscriptionId();
            Store.Id= Guid.NewGuid();
            return HandleResponse(await Mediator.Send(new Create.Command { Store = Store }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostStoreDto Store)
        {
            Store.SubscriptionId= GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Edit.Command { Store = Store }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
