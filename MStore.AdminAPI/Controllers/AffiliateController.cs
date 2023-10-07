using System;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.Dtos.MarketingDto.AffiliateDto;
using MStore.Application.MarketingBL.AffiliateBL;

namespace MStore.AdminAPI.Controllers
{
	public class AffiliateController: BaseApiController
    {

            [HttpGet]
            public async Task<IActionResult> GetList()
            {
                return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
            }
            [HttpPost]
            public async Task<IActionResult> Create(PostAffiliateDto Affiliate)
            {
                Affiliate.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Create.Command { Affiliate = Affiliate }));
            }

            [HttpGet("{Id}")]
            public async Task<IActionResult> Details(Guid Id)
            {
                return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
            }

            [HttpPut("{Id}")]
            public async Task<IActionResult> Edit(PostAffiliateDto Affiliate)
            {
                Affiliate.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Edit.Command { Affiliate = Affiliate }));
            }

            [HttpDelete("{Id}")]
            public async Task<IActionResult> Delete(Guid Id)
            {
               return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
            }


        }
    }

	
