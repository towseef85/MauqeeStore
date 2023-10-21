using Microsoft.AspNetCore.Mvc;
using MStore.Application.FinanceBL.CurrencyBL;
using MStore.Application.Dtos.FinanceDto.CurrencyDto;

namespace MStore.AdminAPI.Controllers
{

    public class CurrencyController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostCurrencyDto Currency)
        {
            Currency.SubscriptionId = GetSubscriptionId();
            Currency.Id= Guid.NewGuid();
            return HandleResponse(await Mediator.Send(new Create.Command { Currency = Currency }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostCurrencyDto Currency)
        {
            Currency.SubscriptionId = GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Edit.Command { Currency = Currency }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)

        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
    }
}
