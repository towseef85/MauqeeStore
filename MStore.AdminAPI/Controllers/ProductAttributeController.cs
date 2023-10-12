using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.ProductAttributeBL;
using MStore.Application.Dtos.CatalogDtos.ProductAttributeDto;

namespace MStore.AdminAPI.Controllers
{

    public class ProductAttributeController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostProductAttributeDto ProductAttribute)
        {
            ProductAttribute.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { ProductAttribute = ProductAttribute }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostProductAttributeDto ProductAttribute)
        {
            ProductAttribute.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { ProductAttribute = ProductAttribute }));
        }
    }
}
