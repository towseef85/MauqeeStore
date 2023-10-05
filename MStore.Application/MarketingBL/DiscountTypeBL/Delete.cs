
using global::MStore.Application.Core;
using global::MStore.Application.Interfaces;
using MediatR;
namespace MStore.Application.MarketingBL.DiscountTypeBL
{
   
        public class Delete
        {
            public class Command : IRequest<Result<Unit>>
            {
                public Guid Id { get; set; }
            }
            public class Handler : IRequestHandler<Command, Result<Unit>>
            {
                private readonly IDiscountTypeRepository _iDiscountTypeRepo;
                public Handler(IDiscountTypeRepository iDiscountTypeRepo)
                {
                _iDiscountTypeRepo = iDiscountTypeRepo;
                }

                public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
                {

                    var result = await _iDiscountTypeRepo.DeleteDiscountType(request.Id);
                    if (!result) return Result<Unit>.Failure("Delete Failed");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }
