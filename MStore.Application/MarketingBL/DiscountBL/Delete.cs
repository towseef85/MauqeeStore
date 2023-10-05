
using global::MStore.Application.Core;
using global::MStore.Application.Interfaces;
using MediatR;
namespace MStore.Application.MarketingBL.DiscountBL
{
   
        public class Delete
        {
            public class Command : IRequest<Result<Unit>>
            {
                public Guid Id { get; set; }
            }
            public class Handler : IRequestHandler<Command, Result<Unit>>
            {
                private readonly IDiscountRepository _iDiscountRepo;
                public Handler(IDiscountRepository iDiscountRepo)
                {
                _iDiscountRepo = iDiscountRepo;
                }

                public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
                {

                    var result = await _iDiscountRepo.DeleteDiscount(request.Id);
                    if (!result) return Result<Unit>.Failure("Delete Failed");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }

