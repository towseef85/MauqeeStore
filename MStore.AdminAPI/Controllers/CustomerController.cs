using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.CustomerBL;
using MStore.Application.Dtos.CustomerDto;

namespace MStore.AdminAPI.Controllers
{
    
    
    public class CustomerController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(PostCustomerDto Customer)
        {
            Customer.SubscriptionId = GetSubscriptionId();
            return HandleResult(await Mediator.Send(new Create.Command { Customer = Customer }));
        }

    }
}
