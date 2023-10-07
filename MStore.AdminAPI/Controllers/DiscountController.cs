using System;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.Dtos.MarketingDto.DiscountDto;
using MStore.Application.MarketingBL.DiscountBL;

namespace MStore.AdminAPI.Controllers
{
	public class DiscountController: BaseApiController
    {

            [HttpGet]
            public async Task<IActionResult> GetList()
            {
                return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
            }
            [HttpPost]
            public async Task<IActionResult> Create(PostDiscountDto Discount)
            {
                Discount.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Create.Command { Discount = Discount }));
            }

            [HttpGet("{Id}")]
            public async Task<IActionResult> Details(Guid Id)
            {
                return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
            }

            [HttpPut("{Id}")]
            public async Task<IActionResult> Edit(PostDiscountDto Discount)
            {
                Discount.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Edit.Command { Discount = Discount }));
            }

            [HttpDelete("{Id}")]
            public async Task<IActionResult> Delete(Guid Id)
            {
               return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
            }


        }
    }

	
