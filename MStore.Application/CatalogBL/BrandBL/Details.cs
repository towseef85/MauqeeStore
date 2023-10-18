using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.BrandDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.BrandBL
{
    public class Details
    {
        public class Query  : IRequest<ServiceStatus<GetBrandDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetBrandDto>>
        {
            private readonly IBrandRepository _iBrandRepo;
            public Handler(IBrandRepository iBrandRepo)
            {
                _iBrandRepo = iBrandRepo;
            }

            public async Task<ServiceStatus<GetBrandDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iBrandRepo.GetBrandById(request.Id);
                return result;

            }
        }
    }
}
