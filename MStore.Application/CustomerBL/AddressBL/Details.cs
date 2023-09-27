using System;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CustomerDto.AddressDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CustomerBL.AddressBL
{
	public class Details
    {
        public class Query : IRequest<Result<GetAddressDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetAddressDto>>
        {
            private readonly IAddressRepository _iAddressRepo;
            public Handler(IAddressRepository iAddressRepo)
            {
                _iAddressRepo = iAddressRepo;
            }

            public async Task<Result<GetAddressDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iAddressRepo.GetAddressById(request.Id);
                return Result<GetAddressDto>.Success(result);

            }
        }
    }
}

