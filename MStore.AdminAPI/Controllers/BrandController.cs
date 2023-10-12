using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.BrandBL;
using MStore.Application.Dtos.CatalogDtos.BrandDto;

namespace MStore.AdminAPI.Controllers
{

    public class BrandController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostBrandDto Brand)
        {
            Brand.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { Brand = Brand }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostBrandDto Brand)
        {
            Brand.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { Brand = Brand }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
