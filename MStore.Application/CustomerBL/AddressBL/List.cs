using System;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CustomerDto.AddressDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CustomerBL.AddressBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetAddressDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetAddressDto>>>
        {
            private readonly IAddressRepository _iAddressRepo;
            public Handler(IAddressRepository iAddressRepo)
            {
                _iAddressRepo = iAddressRepo;
            }
            public async Task<Result<List<GetAddressDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iAddressRepo.GetAllAddress(request.SubscriptionId);
                return Result<List<GetAddressDto>>.Success(result);
            }
        }
    }
}

