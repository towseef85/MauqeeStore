using System;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CustomerDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CustomerBL
{
	public class Details
    {
        public class Query : IRequest<Result<GetCustomerDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetCustomerDto>>
        {
            private readonly ICustomerRepository _iCustomerRepo;
            public Handler(ICustomerRepository iCustomerRepo)
            {
                _iCustomerRepo = iCustomerRepo;
            }

            public async Task<Result<GetCustomerDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iCustomerRepo.GetCustomerById(request.Id);
                return Result<GetCustomerDto>.Success(result);

            }
        }
    }
}

