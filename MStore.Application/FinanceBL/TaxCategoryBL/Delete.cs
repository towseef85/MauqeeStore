using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.TaxCategoryBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ITaxCategoryRepository _iTaxCategoryRepo;
            public Handler(ITaxCategoryRepository iTaxCategoryRepo)
            {
                _iTaxCategoryRepo = iTaxCategoryRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iTaxCategoryRepo.DeleteTaxCategory(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to update Tax Category");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
