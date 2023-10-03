
using global::MStore.Application.Core;
using global::MStore.Application.Interfaces;
using MediatR;
namespace MStore.Application.CustomerBL.AddressBL
{
   
        public class Delete
        {
            public class Command : IRequest<Result<Unit>>
            {
                public Guid Id { get; set; }
            }
            public class Handler : IRequestHandler<Command, Result<Unit>>
            {
                private readonly IAddressRepository _iAddressRepo;
                public Handler(IAddressRepository iAddressRepo)
                {
                _iAddressRepo = iAddressRepo;
                }

                public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
                {

                    var result = await _iAddressRepo.DeleteAddress(request.Id);
                    if (!result) return Result<Unit>.Failure("Delete Failed");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }

