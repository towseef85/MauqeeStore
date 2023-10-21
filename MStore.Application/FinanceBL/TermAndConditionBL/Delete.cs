using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.TermAndConditionBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly ITermAndConditionRepository _iTermAndConditionRepo;
            public Handler(ITermAndConditionRepository iTermAndConditionRepo)
            {
                _iTermAndConditionRepo = iTermAndConditionRepo;
            }

            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iTermAndConditionRepo.DeleteTermAndCondition(request.Id);
                return result;
               
            }
        }
    }
}
