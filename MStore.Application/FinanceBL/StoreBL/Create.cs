using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.StoreDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.StoreBL
{
    public class Create
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostStoreDto Store { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Store).SetValidator(new StoreValidation());
            }
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
                var result = await _iStoreRepo.AddStore(request.Store, cancellationToken);

                return result;
    
            }
        }
    }
}
