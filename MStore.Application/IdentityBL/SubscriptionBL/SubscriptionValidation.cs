using FluentValidation;
using MStore.Application.Dtos.SubscriptionDtos;

namespace MStore.Application.IdentityBL.SubscriptionBL
{
    public class SubscriptionValidation : AbstractValidator<PostSubscriptionDto>
    {
        public SubscriptionValidation()
        {
            RuleFor(x => x.EngName).NotEmpty();
            RuleFor(x => x.ArbName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.PlanId).NotEmpty();
        }
    }
}
