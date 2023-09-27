using System;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.Brand;
using MStore.Application.Dtos.CustomerDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CustomerBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetCustomerDto>>>
        {
            public Guid SubscriptionId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetCustomerDto>>>
        {
            private readonly ICustomerRepository _iCustomerRepo;
            public Handler(ICustomerRepository iCustomerRepo)
            {
                _iCustomerRepo = iCustomerRepo;
            }
            public async Task<Result<List<GetCustomerDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iCustomerRepo.GetAllCustomer(request.SubscriptionId);
                return Result<List<GetCustomerDto>>.Success(result);
            }
        }
    }
}

