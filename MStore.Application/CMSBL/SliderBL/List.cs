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
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetSliderDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetSliderDto>>>
        {
            private readonly ISliderRepository _iSliderRepo;
            public Handler(ISliderRepository iSliderRepo)
            {
                _iSliderRepo = iSliderRepo;
            }
            public async Task<ServiceStatus<List<GetSliderDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iSliderRepo.GetAllSlider(request.SubscriptionId);
                
            }
        }
    }
}
