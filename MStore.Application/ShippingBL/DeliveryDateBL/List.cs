using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.DeliveryDateDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.DeliveryDateBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetDeliveryDateDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetDeliveryDateDto>>>
        {
            private readonly IDeliveryDateRepository _iDeliveryDateRepo;
            public Handler(IDeliveryDateRepository iDeliveryDateRepo)
            {
                _iDeliveryDateRepo = iDeliveryDateRepo;
            }
            public async Task<Result<List<GetDeliveryDateDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iDeliveryDateRepo.GetAllDeliveryDate(request.SubscriptionId);
                return Result<List<GetDeliveryDateDto>>.Success(result);
            }
        }
    }
}
