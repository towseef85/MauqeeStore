using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.CategoryBL;
using MStore.Application.Dtos.CatalogDtos.Category;

namespace MStore.AdminAPI.Controllers
{
   
    public class CategoryController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(PostCategoryDto Category)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Category = Category }));
        }
    }
}
