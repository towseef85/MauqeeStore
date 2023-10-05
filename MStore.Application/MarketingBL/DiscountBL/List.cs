using System;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.MarketingDto.DiscountDto;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.DiscountBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetDiscountDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetDiscountDto>>>
        {
            private readonly IDiscountRepository _iDiscountRepo;
            public Handler(IDiscountRepository iDiscountRepo)
            {
                _iDiscountRepo = iDiscountRepo;
            }
            public async Task<Result<List<GetDiscountDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iDiscountRepo.GetAllDiscount(request.SubscriptionId);
                return Result<List<GetDiscountDto>>.Success(result);
            }
        }
    }
}

