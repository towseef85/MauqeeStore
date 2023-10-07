using FluentValidation;
using MStore.Application.Dtos.MarketingDto.AffiliateDto;

namespace MStore.Application.MarketingBL.AffiliateBL
{
    public class AffiliateValidation : AbstractValidator<PostAffiliateDto>
    {
        public AffiliateValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
