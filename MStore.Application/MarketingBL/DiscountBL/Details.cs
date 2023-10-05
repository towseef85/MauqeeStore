using System;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.MarketingDto.DiscountDto;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.DiscountBL
{
	public class Details
    {
        public class Query : IRequest<Result<GetDiscountDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetDiscountDto>>
        {
            private readonly IDiscountRepository _iDiscountRepo;
            public Handler(IDiscountRepository iDiscountRepo)
            {
                _iDiscountRepo = iDiscountRepo;
            }

            public async Task<Result<GetDiscountDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iDiscountRepo.GetDiscountById(request.Id);
                return Result<GetDiscountDto>.Success(result);

            }
        }
    }
}

