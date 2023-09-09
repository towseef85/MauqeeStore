using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CMSDtos.Slider;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CMSBL.SliderBL
{
    public class Create
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostSliderDto Slider { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Slider).SetValidator(new SliderValidation());
            }
        }

        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly ISliderRepository _iSliderRepo;
            public Handler(ISliderRepository iSliderRepo)
            {
                _iSliderRepo = iSliderRepo;
            }
            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iSliderRepo.AddSlider(request.Slider, cancellationToken);
                return result;
            }
        }
    }
}
