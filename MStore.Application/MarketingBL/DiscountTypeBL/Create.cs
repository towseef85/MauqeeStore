using System;
using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.MarketingDto.DiscountTypeDto;
using MStore.Application.Interfaces;

namespace MStore.Application.MarketingBL.DiscountTypeBL
{
    public class Create
        {
            public class Command : IRequest<Result<Unit>>
            {
                public PostDiscountTypeDto DiscountType { get; set; }
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.DiscountType).SetValidator(new DiscountTypeValidation());
                }
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
                    var result = await _iDiscountTypeRepo.AddDiscountType(request.DiscountType, cancellationToken);
                    if (!result) return Result<Unit>.Failure("Unable to add DiscountType");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }

