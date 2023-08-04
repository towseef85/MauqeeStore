using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.BrandBL;
using MStore.Application.Dtos.CatalogDtos.Brand;
using System.Security.Claims;

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

     
    }
}
