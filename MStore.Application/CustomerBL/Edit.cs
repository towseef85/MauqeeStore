using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CustomerDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CustomerBL
{

        public class Edit
        {
            public class Command : IRequest<Result<Unit>>
            {
                public PostCustomerDto Customer { get; set; }
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.Customer).SetValidator(new CustomerValidation());
                }
            }

            public class Handler : IRequestHandler<Command, Result<Unit>>
            {
                private readonly ICustomerRepository _iCustomerRepo;
                public Handler(ICustomerRepository iCustomerRepo)
                {
                    _iCustomerRepo = iCustomerRepo;
                }
                public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
                {
                    var result = await _iCustomerRepo.UpdateCustomer(request.Customer, cancellationToken);
                    if (!result) return Result<Unit>.Failure("Unable to add Brand");
                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
    }

