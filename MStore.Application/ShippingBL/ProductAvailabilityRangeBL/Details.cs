using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.ProductAvailabilityRangeDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.ProductAvailabilityRangeBL
{
    public class Details
    {
        public class Query  : IRequest<Result<GetProductAvailabilityRangeDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetProductAvailabilityRangeDto>>
        {
            private readonly IProductAvailabilityRangeRepository _iProductAvailabilityRangeRepo;
            public Handler(IProductAvailabilityRangeRepository iProductAvailabilityRangeRepo)
            {
                _iProductAvailabilityRangeRepo = iProductAvailabilityRangeRepo;
            }

            public async Task<Result<GetProductAvailabilityRangeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iProductAvailabilityRangeRepo.GetProductAvailabilityRangeById(request.Id);
                 return Result<GetProductAvailabilityRangeDto>.Success(result);

            }
        }
    }
}

 