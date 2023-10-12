using Microsoft.AspNetCore.Mvc;
using MStore.Application.FinanceBL.CountryBL;
using MStore.Application.Dtos.FinanceDto.CountryDto;

namespace MStore.AdminAPI.Controllers
{

    public class CountryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostCountryDto Country)
        {
            Country.SubscriptionId = GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Create.Command { Country = Country }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostCountryDto Country)
        {
            Country.SubscriptionId = GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Edit.Command { Country = Country }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)

        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
    }
}
