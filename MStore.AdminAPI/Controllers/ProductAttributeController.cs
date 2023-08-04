using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.ProductAttributeBL;
using MStore.Application.Dtos.CatalogDtos.ProductAttribute;

namespace MStore.AdminAPI.Controllers
{

    public class ProductAttributeController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList(Guid SubscriptionId)
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = SubscriptionId }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostProductAttributeDto ProductAttribute)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ProductAttribute = ProductAttribute }));
        }
    }
}
