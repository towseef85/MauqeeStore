using System;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.MarketingDto.DiscountTypeDto;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.DiscountTypeBL
{
	public class Details
    {
        public class Query : IRequest<Result<GetDiscountTypeDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetDiscountTypeDto>>
        {
            private readonly IDiscountTypeRepository _iDiscountTypeRepo;
            public Handler(IDiscountTypeRepository iDiscountTypeRepo)
            {
                _iDiscountTypeRepo = iDiscountTypeRepo;
            }

            public async Task<Result<GetDiscountTypeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iDiscountTypeRepo.GetDiscountTypeById(request.Id);
                return Result<GetDiscountTypeDto>.Success(result);

            }
        }
    }
}

