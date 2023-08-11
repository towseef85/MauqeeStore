using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.TaxCategory;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.FinanceBL.TaxCategoryBL
{
    public class Create
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
            private readonly ITaxCategoryRepository _ITaxCategoryRepo;
            public Handler(ITaxCategoryRepository ITaxCategoryRepo)
            {
                _ITaxCategoryRepo = ITaxCategoryRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _ITaxCategoryRepo.AddTaxCategory(request.TaxCategory, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add TaxCategory");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
