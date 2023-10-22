using Microsoft.AspNetCore.Mvc;
using MStore.Application.CatalogBL.ProductReviewBL;
using MStore.Application.Dtos.CatalogDtos.ProductReviewDto;

namespace MStore.AdminAPI.Controllers
{

    public class ProductReviewController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostProductReviewDto ProductReview)
        {
            ProductReview.SubscriptionId = GetSubscriptionId();
            ProductReview.Id= Guid.NewGuid();
            return HandleResponse(await Mediator.Send(new Create.Command { ProductReview = ProductReview }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostProductReviewDto ProductReview)
        {
            ProductReview.SubscriptionId= GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Edit.Command { ProductReview = ProductReview }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
        
     
    }
}
