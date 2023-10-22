using FluentValidation;
using MStore.Application.Dtos.FinanceDto.FaqDto;

namespace MStore.Application.FinanceBL.FaqBL
{
    public class FaqValidation : AbstractValidator<PostFaqDto>
    {
        public FaqValidation()
        {
            RuleFor(x => x.Question).NotEmpty();
            RuleFor(x => x.Answer).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}
