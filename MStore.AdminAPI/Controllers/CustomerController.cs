using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.CustomerBL;
using MStore.Application.Dtos.CatalogDtos.Brand;
using MStore.Application.Dtos.CustomerDto;

namespace MStore.AdminAPI.Controllers
{
    
    
    public class CustomerController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostCustomerDto Customer)
        {
            Customer.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { Customer = Customer }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostCustomerDto Customer)
        {
            Customer.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Edit.Command { Customer = Customer }));
        }

    }
}
