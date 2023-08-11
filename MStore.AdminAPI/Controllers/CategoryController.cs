using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.CategoryBL;
using MStore.Application.Dtos.CatalogDtos.Brand;
using MStore.Application.Dtos.CatalogDtos.Category;

namespace MStore.AdminAPI.Controllers
{

    public class CategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostCategoryDto Category)
        {
            Category.SubscriptionId= GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { Category = Category }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostCategoryDto Category)
        {
            Category.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { Category = Category }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
    }
}
