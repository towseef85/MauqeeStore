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
    public class Details
    {
        public class Query : IRequest<ServiceStatus<GetSliderDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetSliderDto>>
        {
            private readonly ISliderRepository _iSliderRepo;
            public Handler(ISliderRepository iSliderRepo)
            {
                _iSliderRepo = iSliderRepo;
            }

            public async Task<ServiceStatus<GetSliderDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iSliderRepo.GetSliderById(request.Id);
            }
        }
    }
}
