using Microsoft.AspNetCore.Mvc;
using MStore.Application.ShippingBL.ProductAvailabilityRangeBL;
using MStore.Application.Dtos.ShippingDto.ProductAvailabilityRangeDto;

namespace MStore.AdminAPI.Controllers
{

    public class ProductAvailabilityRangeController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostProductAvailabilityRangeDto ProductAvailabilityRange)
        {
            ProductAvailabilityRange.SubscriptionId = GetSubscriptionId();
            ProductAvailabilityRange.Id= Guid.NewGuid();
            return HandleResult(await Mediator.Send(new Create.Command { ProductAvailabilityRange = ProductAvailabilityRange }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostProductAvailabilityRangeDto ProductAvailabilityRange)
        {
            ProductAvailabilityRange.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { ProductAvailabilityRange = ProductAvailabilityRange }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
