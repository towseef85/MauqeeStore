
using System;
using FluentValidation;
using MStore.Application.Dtos.MarketingDto.DiscountTypeDto;

namespace MStore.Application.MarketingBL.DiscountTypeBL
{
    public class DiscountTypeValidation : AbstractValidator<PostDiscountTypeDto>
    {
        public DiscountTypeValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}

