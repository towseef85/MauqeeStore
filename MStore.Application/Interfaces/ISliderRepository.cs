using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CMSDtos.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Interfaces
{
    public interface ISliderRepository
    {
        Task<ServiceStatus<List<GetSliderDto>>> GetAllSlider(Guid subscriptionId);
        Task<ServiceStatus<GetSliderDto>> GetSliderById(Guid SliderId);
        Task<ServiceStatus<Unit>> AddSlider(PostSliderDto PostSliderDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateSlider(PostSliderDto PostSliderDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteSlider(Guid SliderId);
    }
}
