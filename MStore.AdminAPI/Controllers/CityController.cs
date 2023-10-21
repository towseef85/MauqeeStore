using Microsoft.AspNetCore.Mvc;
using MStore.Application.FinanceBL.CityBL;
using MStore.Application.Dtos.FinanceDto.CityDto;

namespace MStore.AdminAPI.Controllers
{

    public class CityController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostCityDto City)
        {
            City.SubscriptionId = GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Create.Command { City = City }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostCityDto City)
        {
            City.SubscriptionId = GetSubscriptionId();
            City.Id= Guid.NewGuid();
            return HandleResponse(await Mediator.Send(new Edit.Command { City = City }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)

        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
    }
}
