using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.FaqDto;
using MStore.Application.Interfaces;

namespace MStore.Application.FinanceBL.FaqBL
{
    public class Create
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostFaqDto Faq { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Faq).SetValidator(new FaqValidation());
            }
        }

        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly IFaqRepository _iFaqRepo;
            public Handler(IFaqRepository iFaqRepo)
            {
                _iFaqRepo = iFaqRepo;
            }
            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iFaqRepo.AddFaq(request.Faq, cancellationToken);

                return result;
    
            }
        }
    }
}
