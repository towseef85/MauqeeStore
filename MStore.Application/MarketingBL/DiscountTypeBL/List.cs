using System;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.MarketingDto.DiscountTypeDto;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.DiscountTypeBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetDiscountTypeDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetDiscountTypeDto>>>
        {
            private readonly IDiscountTypeRepository _iDiscountTypeRepo;
            public Handler(IDiscountTypeRepository iDiscountTypeRepo)
            {
                _iDiscountTypeRepo = iDiscountTypeRepo;
            }
            public async Task<Result<List<GetDiscountTypeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iDiscountTypeRepo.GetAllDiscountType(request.SubscriptionId);
                return Result<List<GetDiscountTypeDto>>.Success(result);
            }
        }
    }
}

