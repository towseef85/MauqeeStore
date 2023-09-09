using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CMSDtos.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Interfaces
{
    public interface IOffersRepository
    {
         Task<ServiceStatus<List<GetOffersDto>>> GetAllOffers(Guid subscriptionId);
        Task<ServiceStatus<GetOffersDto>> GetOffersById(Guid OffersId);
        Task<ServiceStatus<Unit>> AddOffers(PostOffersDto PostOffersDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateOffers(PostOffersDto PostOffersDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteOffers(Guid OffersId);
    }
}
