using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.FaqBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly IFaqRepository _iFaqRepo;
            public Handler(IFaqRepository iFaqRepo)
            {
                _iFaqRepo = iFaqRepo;
            }

            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iFaqRepo.DeleteFaq(request.Id);
                return result;
               
            }
        }
    }
}
