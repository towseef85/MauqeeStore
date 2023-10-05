using System;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.Dtos.MarketingDto.DiscountTypeDto;
using MStore.Application.MarketingBL.DiscountTypeBL;


namespace MStore.AdminAPI.Controllers
{
	public class DiscountTypeController: BaseApiController
    {
        [HttpGet]
            public async Task<IActionResult> GetList()
            {
                return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
            }
            [HttpPost]
            public async Task<IActionResult> Create(PostDiscountTypeDto DiscountType)
            {
                DiscountType.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Create.Command { DiscountType = DiscountType }));
            }

            [HttpGet("{Id}")]
            public async Task<IActionResult> Details(Guid Id)
            {
                return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
            }

            [HttpPut("{Id}")]
            public async Task<IActionResult> Edit(PostDiscountTypeDto DiscountType)
            {
                DiscountType.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Edit.Command { DiscountType = DiscountType }));
            }

            [HttpDelete("{Id}")]
            public async Task<IActionResult> Delete(Guid Id)
            {
               return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
            }


        }
    }
