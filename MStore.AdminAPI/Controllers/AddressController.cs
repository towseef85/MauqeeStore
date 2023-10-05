using System;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.Dtos.CustomerDto.AddressDto;
using MStore.Application.CustomerBL.AddressBL;

namespace MStore.AdminAPI.Controllers
{
	public class AddressController: BaseApiController
    {

            [HttpGet]
            public async Task<IActionResult> GetList()
            {
                return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
            }
            [HttpPost]
            public async Task<IActionResult> Create(PostAddressDto Address)
            {
                Address.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Create.Command { Address = Address }));
            }

            [HttpGet("{Id}")]
            public async Task<IActionResult> Details(Guid Id)
            {
                return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
            }

            [HttpPut("{Id}")]
            public async Task<IActionResult> Edit(PostAddressDto Address)
            {
                Address.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Edit.Command { Address = Address }));
            }

            [HttpDelete("{Id}")]
            public async Task<IActionResult> Delete(Guid Id)
            {
               return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
            }


        }
    }

	
