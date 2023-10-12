using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.DeliveryDateDto;
using MStore.Application.Interfaces;

namespace MStore.Application.ShippingBL.DeliveryDateBL
{
    public class Details
    {
        public class Query  : IRequest<Result<GetDeliveryDateDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetDeliveryDateDto>>
        {
            private readonly IDeliveryDateRepository _iDeliveryDateRepo;
            public Handler(IDeliveryDateRepository iDeliveryDateRepo)
            {
                _iDeliveryDateRepo = iDeliveryDateRepo;
            }

            public async Task<Result<GetDeliveryDateDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iDeliveryDateRepo.GetDeliveryDateById(request.Id);
                 return Result<GetDeliveryDateDto>.Success(result);

            }
        }
    }
}

 