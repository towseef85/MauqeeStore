using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.BrandBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly IBrandRepository _iBrandRepo;
            public Handler(IBrandRepository iBrandRepo)
            {
                _iBrandRepo = iBrandRepo;
            }

            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iBrandRepo.DeleteBrand(request.Id);
                return result;
               
            }
        }
    }
}
