using Microsoft.AspNetCore.Mvc;
using MStore.Application.Dtos.CatalogDtos.TaxCategory;
using MStore.Application.FinanceBL.TaxCategoryBL;

namespace MStore.AdminAPI.Controllers
{

    public class TaxCategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostTaxCategoryDto TaxCategory)
        {
            TaxCategory.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { TaxCategory = TaxCategory }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostTaxCategoryDto TaxCategory)
        {
            TaxCategory.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { TaxCategory = TaxCategory }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
        }
    }
}
