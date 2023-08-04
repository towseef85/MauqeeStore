using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.Dtos.SubscriptionDtos;
using MStore.Application.IdentityBL.SubscriptionBL;

namespace MStore.AdminAPI.Controllers
{
 
    public class SubscriptionController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
        [AllowAnonymous]
        [HttpPost]
       
        public async Task<IActionResult> Create(PostSubscriptionDto Subscription)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Subscription = Subscription }));
        }
        [AllowAnonymous]
        [HttpPost("CreatePlan")]
        public async Task<IActionResult> CreatePlan(PostPlanDto Plan)
        {
            return HandleResult(await Mediator.Send(new CreatePlan.Command { Plan = Plan }));
        }
    }
}
