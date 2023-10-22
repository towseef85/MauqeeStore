using Microsoft.AspNetCore.Mvc;
using MStore.Application.FinanceBL.FaqBL;
using MStore.Application.Dtos.FinanceDto.FaqDto;

namespace MStore.AdminAPI.Controllers
{

    public class FaqController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostFaqDto Faq)
        {
            Faq.SubscriptionId = GetSubscriptionId();
            Faq.Id= Guid.NewGuid();
            return HandleResponse(await Mediator.Send(new Create.Command { Faq = Faq }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostFaqDto Faq)
        {
            Faq.SubscriptionId= GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Edit.Command { Faq = Faq }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
