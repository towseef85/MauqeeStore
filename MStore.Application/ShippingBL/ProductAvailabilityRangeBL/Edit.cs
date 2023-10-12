using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.ProductAvailabilityRangeDto;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.ShippingBL.ProductAvailabilityRangeBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostProductAvailabilityRangeDto ProductAvailabilityRange { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductAvailabilityRange).SetValidator(new ProductAvailabilityRangeValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IProductAvailabilityRangeRepository _iProductAvailabilityRangeRepo;
            public Handler(IProductAvailabilityRangeRepository iProductAvailabilityRangeRepo)
            {
                _iProductAvailabilityRangeRepo = iProductAvailabilityRangeRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iProductAvailabilityRangeRepo.UpdateProductAvailabilityRange(request.ProductAvailabilityRange, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Delivery Date");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
