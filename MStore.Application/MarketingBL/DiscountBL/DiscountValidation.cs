using System;
using FluentValidation;
using MStore.Application.Dtos.MarketingDto.DiscountDto;

namespace MStore.Application.MarketingBL.DiscountBL
{
    public class DiscountValidation : AbstractValidator<PostDiscountDto>
    {
        public DiscountValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}

