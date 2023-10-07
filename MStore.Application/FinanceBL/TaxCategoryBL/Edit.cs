using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.TaxCategoryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.TaxCategoryBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostTaxCategoryDto TaxCategory { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.TaxCategory).SetValidator(new TaxCategoryValidation());
            }
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
                var result = await _iTaxCategoryRepo.UpdateTaxCategory(request.TaxCategory, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add TaxCategory");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
