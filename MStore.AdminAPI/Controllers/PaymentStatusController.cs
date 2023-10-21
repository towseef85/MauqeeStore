using Microsoft.AspNetCore.Mvc;
using MStore.Application.FinanceBL.PaymentStatusBL;
using MStore.Application.Dtos.FinanceDto.PaymentStatusDto;

namespace MStore.AdminAPI.Controllers
{

    public class PaymentStatusController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostPaymentStatusDto PaymentStatus)
        {
            PaymentStatus.SubscriptionId = GetSubscriptionId();
            PaymentStatus.Id= Guid.NewGuid();
            return HandleResponse(await Mediator.Send(new Create.Command { PaymentStatus = PaymentStatus }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostPaymentStatusDto PaymentStatus)
        {
            PaymentStatus.SubscriptionId= GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Edit.Command { PaymentStatus = PaymentStatus }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
