using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CMSBL.SliderBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
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

                var result = await _iSliderRepo.DeleteSlider(request.Id);
                return result;
            }
        }
    }
}
