using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.CurrencyBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly ICurrencyRepository _iCurrencyRepo;
            public Handler(ICurrencyRepository iCurrencyRepo)
            {
                _iCurrencyRepo = iCurrencyRepo;
            }

            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iCurrencyRepo.DeleteCurrency(request.Id);
                return result;
            }
        }
    }
}
