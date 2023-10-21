using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.CMSBL.SliderBL;
using MStore.Application.Dtos.CMSDtos.Slider;

namespace MStore.AdminAPI.Controllers
{

    public class SliderController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResponse(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostSliderDto Slider)
        {
            Slider.SubscriptionId = GetSubscriptionId();
            Slider.Id= Guid.NewGuid();
            return HandleResponse(await Mediator.Send(new Create.Command { Slider = Slider }));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(Guid Id)
        {
            return HandleResponse(await Mediator.Send(new Details.Query { Id = Id }));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Edit(PostSliderDto Slider)
        {
            Slider.SubscriptionId = GetSubscriptionId();
            return HandleResponse(await Mediator.Send(new Edit.Command { Slider = Slider }));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)

        {
            return HandleResponse(await Mediator.Send(new Delete.Command { Id = Id }));
        }
    }
}
