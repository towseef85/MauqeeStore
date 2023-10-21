using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.CMSBL.OffersBL;
using MStore.Application.Dtos.CMSDtos.Offers;

namespace MStore.AdminAPI.Controllers
{
   
    public class OffersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostOffersDto Offers)
        {
            Offers.SubscriptionId = GetSubscriptionId();
            Offers.Id= Guid.NewGuid();
            return HandleResponse(await Mediator.Send(new Create.Command { Offers = Offers }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostOffersDto Offers)
        {
            Offers.SubscriptionId = GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Edit.Command { Offers = Offers }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)

        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
    }
}
