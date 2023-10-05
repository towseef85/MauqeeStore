using System;
using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.MarketingDto.DiscountDto;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.DiscountBL
{
    public class Create
        {
            public class Command : IRequest<Result<Unit>>
            {
                public PostDiscountDto Discount { get; set; }
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.Discount).SetValidator(new DiscountValidation());
                }
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
                    var result = await _iDiscountRepo.AddDiscount(request.Discount, cancellationToken);
                    if (!result) return Result<Unit>.Failure("Unable to add Discount");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }

