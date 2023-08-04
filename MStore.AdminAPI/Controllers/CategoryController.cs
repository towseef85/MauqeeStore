using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.CategoryBL;
using MStore.Application.Dtos.CatalogDtos.Category;

namespace MStore.AdminAPI.Controllers
{

    public class CategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList(Guid SubscriptionId)
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = SubscriptionId }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostCategoryDto Category)
        {
            Category.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { Category = Category }));
        }
    }
}
