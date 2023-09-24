using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.ProductBL;
using MStore.Application.Dtos.CatalogDtos.Product;

namespace MStore.AdminAPI.Controllers
{

    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostProductDto Product)
        {
            Product.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { Product = Product }));
        }
    }
}
