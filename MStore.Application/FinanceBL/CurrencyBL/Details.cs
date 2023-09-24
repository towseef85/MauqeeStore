using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CurrencyDto;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.FinanceBL.CurrencyBL
{
    public class Details
    {
        public class Query : IRequest<ServiceStatus<GetCurrencyDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ServiceStatus<GetCurrencyDto>>
        {
            private readonly ICurrencyRepository _iCurrencyRepo;
            public Handler(ICurrencyRepository iCurrencyRepo)
            {
                _iCurrencyRepo = iCurrencyRepo;
            }

            public async Task<ServiceStatus<GetCurrencyDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _iCurrencyRepo.GetCurrencyById(request.Id);
            }
        }
    }
}
