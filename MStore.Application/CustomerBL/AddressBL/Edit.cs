using System;
using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CustomerDto.AddressDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CustomerBL.AddressBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostAddressDto Address { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Address).SetValidator(new AddressValidation());
            }
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
                var result = await _iAddressRepo.UpdateAddress(request.Address, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Address");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}

