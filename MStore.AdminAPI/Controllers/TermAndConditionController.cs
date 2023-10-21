using Microsoft.AspNetCore.Mvc;
using MStore.Application.FinanceBL.TermAndConditionBL;
using MStore.Application.Dtos.FinanceDto.TermAndConditionDto;

namespace MStore.AdminAPI.Controllers
{

    public class TermAndConditionController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostTermAndConditionDto TermAndCondition)
        {
            TermAndCondition.SubscriptionId = GetSubscriptionId();
            TermAndCondition.Id= Guid.NewGuid();
            return HandleResponse(await Mediator.Send(new Create.Command { TermAndCondition = TermAndCondition }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostTermAndConditionDto TermAndCondition)
        {
            TermAndCondition.SubscriptionId= GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Edit.Command { TermAndCondition = TermAndCondition }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
