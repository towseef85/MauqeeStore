using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.TermAndConditionDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.TermAndConditionBL
{
    public class Edit
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostTermAndConditionDto TermAndCondition { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.TermAndCondition).SetValidator(new TermAndConditionValidation());
            }
        }

        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly ITermAndConditionRepository _iTermAndConditionRepo;
            public Handler(ITermAndConditionRepository iTermAndConditionRepo)
            {
                _iTermAndConditionRepo = iTermAndConditionRepo;
            }
            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iTermAndConditionRepo.UpdateTermAndCondition(request.TermAndCondition, cancellationToken);
                return result;
            }
        }
    }
}
