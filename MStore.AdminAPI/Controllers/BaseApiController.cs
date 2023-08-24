using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.Core;
using System.Security.Claims;

namespace MStore.AdminAPI.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;

#pragma warning disable CS8603 // Possible null reference return.
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
#pragma warning restore CS8603 // Possible null reference return.

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null)
                return Ok(result.Value);
            if (result.IsSuccess && result.Value == null)
                return NotFound();
            return BadRequest(result.Error);
        }

        
        protected Guid GetSubscriptionId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var value = identity.FindFirst("subscriptionId").Value;
            Guid SubscriptionId = new Guid(value);
            return SubscriptionId;


        }
    }
}
