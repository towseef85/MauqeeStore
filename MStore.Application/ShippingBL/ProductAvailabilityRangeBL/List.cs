using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.ProductAvailabilityRangeDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.ProductAvailabilityRangeBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetProductAvailabilityRangeDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetProductAvailabilityRangeDto>>>
        {
            private readonly IProductAvailabilityRangeRepository _iProductAvailabilityRangeRepo;
            public Handler(IProductAvailabilityRangeRepository iProductAvailabilityRangeRepo)
            {
                _iProductAvailabilityRangeRepo = iProductAvailabilityRangeRepo;
            }
            public async Task<Result<List<GetProductAvailabilityRangeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iProductAvailabilityRangeRepo.GetAllProductAvailabilityRange(request.SubscriptionId);
                return Result<List<GetProductAvailabilityRangeDto>>.Success(result);
            }
        }
    }
}
