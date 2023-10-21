using FluentValidation;
using MStore.Application.Dtos.FinanceDto.TermAndConditionDto;

namespace MStore.Application.FinanceBL.TermAndConditionBL
{
    public class TermAndConditionValidation : AbstractValidator<PostTermAndConditionDto>
    {
        public TermAndConditionValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}
