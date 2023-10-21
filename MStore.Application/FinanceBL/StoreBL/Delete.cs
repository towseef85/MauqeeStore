using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.StoreBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly IStoreRepository _iStoreRepo;
            public Handler(IStoreRepository iStoreRepo)
            {
                _iStoreRepo = iStoreRepo;
            }

            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iStoreRepo.DeleteStore(request.Id);
                return result;
               
            }
        }
    }
}
