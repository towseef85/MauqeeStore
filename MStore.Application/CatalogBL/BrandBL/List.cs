using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.BrandDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.BrandBL
{
    public class List
    {
        public class Query : IRequest<ServiceStatus<List<GetBrandDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<List<GetBrandDto>>>
        {
            private readonly IBrandRepository _iBrandRepo;
            public Handler(IBrandRepository iBrandRepo)
            {
                _iBrandRepo = iBrandRepo;
            }
            public async Task<ServiceStatus<List<GetBrandDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iBrandRepo.GetAllBrand(request.SubscriptionId);
                return result;
            }
        }
    }
}
